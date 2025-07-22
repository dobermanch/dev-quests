using Hearthstone.Game.Cards;
using Hearthstone.Game.Decks;

namespace Hearthstone.Game.Players;

public class Player(IGame game, string name) : IPlayer
{
    private readonly IGame _game = game ?? throw new ArgumentNullException(nameof(game));

    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

    public Deck Deck { get; private set; } = null!;

    public Hand Hand { get; private set; } = null!;

    public Health Health { get; private set; } = null!;

    public ManaCrystals Mana { get; private set; } = null!;

    public bool IsCurrent { get; internal set; }

    public Task PlayCardAsync(Card card, CancellationToken cancellation) 
        => _game.PlayCardAsync(this, card, cancellation);

    public Task EndTurnAsync(CancellationToken cancellation)
        => _game.EndTurnAsync(this, cancellation);

    internal Task ResetAsync(Deck deck, PlayerOptions options, CancellationToken cancellation)
    {
        Deck = deck;
        Hand = new Hand(deck.TakeCards(options.InitialHandSize));
        Mana = new ManaCrystals(options.InitialManaCrystals, options.MaxManaCrystals);
        Health = new Health(options.InitialHitPoints);
        IsCurrent = false;

        return Task.CompletedTask;
    }
}
