using Hearthstone.Game.Cards;
using Hearthstone.Game.Cards.Features;
using Hearthstone.Game.Notifications;
using Hearthstone.Game.Players;
using Hearthstone.Game.Stats;

namespace Hearthstone.Game;

public sealed class Game : IGame
{
    private readonly IList<Player> _players = new List<Player>();
    private readonly IList<IGameNotification> _notification = new List<IGameNotification>();
    private readonly Dictionary<Type, Action<Player, Card>> _cardHandlers;
    private readonly GameOptions _options;
    private GameStats _stats = default!;
    private int _round;

    public Game(GameOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));

        Players = _players.AsReadOnly();
        Notifications = _notification.AsReadOnly();

        // NOTE: Can be replaced with something like ICardHandler
        _cardHandlers = new()
        {
            {typeof(HealCard), HandleHealCard },
            {typeof(DamageCard), HandleDamageCard }
        };
    }

    public IReadOnlyCollection<Player> Players { get; }

    public Player CurrentPlayer { get; private set; } = default!;

    public GameState State { get; private set; }

    public IReadOnlyCollection<IGameNotification> Notifications { get; }

    public Task AddPlayerAsync(string name, CancellationToken cancellation)
    {
        if (State == GameState.InProgress)
        {
            throw new InvalidOperationException("The game already started.");
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (_players.Any(it => it.Name.Equals(name)))
        {
            throw new InvalidOperationException($"The player with '{name}' name already added.");
        }

        var player = new Player(this, name);
        _players.Add(player);

        _options.Logger.GameAddPlayer(player);

        return Task.CompletedTask;
    }

    public async Task StartAsync(CancellationToken cancellation)
    {
        if (State == GameState.InProgress)
        {
            return;
        }

        await ResetAsync(cancellation);

        State = GameState.InProgress;

        _options.Logger.GameStarted(this);
    }

    public Task StopAsync(CancellationToken cancellation)
    {
        if (State == GameState.InProgress)
        {
            State = GameState.Stopped;
            _options.Logger.GameStopped(this);
        }

        return Task.CompletedTask;
    }

    public Task PlayCardAsync(Player player, Card card, CancellationToken cancellation)
    {
        if (State != GameState.InProgress)
        {
            return Task.CompletedTask;
        }

        _notification.Clear();

        if (!player.Mana.HasCrystals(card.Cost))
        {
            _notification.Add(new NotEnoughManaNotification());
            return Task.CompletedTask;
        }

        player.Mana.UseCrystals(card.Cost);
        player.Hand.Remove(card);

        _cardHandlers[card.GetType()](player, card);

        CheckNotifications(player);

        _options.Logger.GamePlayerCard(player, card);

        CheckGameState();

        return Task.CompletedTask;
    }

    public Task EndTurnAsync(Player player, CancellationToken cancellation)
    {
        if (State != GameState.InProgress)
        {
            return Task.CompletedTask;
        }

        player.IsCurrent = false;
        _notification.Clear();
        _round++;

        _options.Logger.GameEndOfTurn(player);

        SetNextPlayer(Players.First(it => it != CurrentPlayer));
        CheckGameState();

        return Task.CompletedTask;
    }

    public ValueTask<GameStats> GetStatsAsync(CancellationToken cancellation) 
        => ValueTask.FromResult(_stats);

    private void CheckGameState()
    {
        if (Players.Any(it => it.Health.IsDead))
        {
            // Wins one that is not dead
            _stats.SetWinner(Players.First(it => !it.Health.IsDead));
            State = GameState.Finished;
        }
        else if (Players.All(it => it.Hand.IsEmpty && it.Deck.IsEmpty))
        {
            // Wins who has more health
            _stats.SetWinner(Players.OrderByDescending(it => it.Health.Current).First());

            State = GameState.Finished;
        }
    }

    private void HandleHealCard(Player player, Card card)
    {
        var health = player.Health.Current;

        player.Health.Increase(card.Value);

        _stats.RecordMove(new PlayerHealMove(_round, player, card, health, player.Health.Current));

        ApplyCardFeature(player, card);
    }

    private void HandleDamageCard(Player player, Card card)
    {
        var targetPlayer = Players.First(it => it != player);
        var health = targetPlayer.Health.Current;
        targetPlayer.Health.Decrease(card.Value);

        _stats.RecordMove(new PlayerDamageMove(_round, player, card, targetPlayer, health, targetPlayer.Health.Current));

        ApplyCardFeature(player, card);
    }

    private void ApplyCardFeature(Player player, Card card)
    {
        foreach (var feature in card.Features ?? Array.Empty<ICardFeature>())
        {
            switch (feature)
            {
                case LegendaryFeature:
                    _notification.Add(new LegendaryCardNotification());
                    break;
                case ExtraManaFeature extraMana:
                    player.Mana.AddCrystal(extraMana.Amount);
                    break;
                case DrawCardFeature:
                    player.Hand.AddRange(player.Deck.TakeCards(1));
                    break;
            }
        }
    }

    private void CheckNotifications(Player player)
    {
        if (player.Hand.IsEmpty)
        {
            _notification.Add(new EmptyHandNotification());
        }

        if (player.Mana.NoCrystals || player.Hand.All(it => it.Cost > player.Mana.Current))
        {
            _notification.Add(new NoManaNotification());
        }
    }

    private void SetNextPlayer(Player player)
    {
        CurrentPlayer = player;
        CurrentPlayer.IsCurrent = true;
        CurrentPlayer.Mana.AddCapacity(1);
        CurrentPlayer.Mana.Reset();

        var card = CurrentPlayer.Deck.TakeCard();
        if (card is null)
        {
            CurrentPlayer.Health.Decrease(1);
        }
        else
        {
            CurrentPlayer.Hand.Add(card);
        }

        CheckNotifications(CurrentPlayer);

        _options.Logger.GameStartTurn(CurrentPlayer);
    }

    private async Task ResetAsync(CancellationToken cancellation)
    {
        await InitPlayers(cancellation);

        _round = 1;
        _stats = new GameStats(_players);

        CurrentPlayer = _options.PlayerSelector.Select(_players);
        CurrentPlayer.IsCurrent = true;
    }

    private async Task InitPlayers(CancellationToken cancellation)
    {
        foreach (var player in _players)
        {
            var deck = _options.DeckProvider.GetDeck();
            deck.Shuffle(_options.ShuffleStrategy);

            await player.ResetAsync(deck, _options.PlayerSettings, cancellation);
        }
    }
}
