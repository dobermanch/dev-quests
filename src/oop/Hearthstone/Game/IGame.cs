using Hearthstone.Game.Cards;
using Hearthstone.Game.Notifications;
using Hearthstone.Game.Players;
using Hearthstone.Game.Stats;

namespace Hearthstone.Game;

public interface IGame
{
    GameState State { get; }

    Player CurrentPlayer { get; }

    IReadOnlyCollection<Player> Players { get; }

    IReadOnlyCollection<IGameNotification> Notifications { get; }

    Task AddPlayerAsync(string name, CancellationToken cancellation);

    Task StartAsync(CancellationToken cancellation);

    Task StopAsync(CancellationToken cancellation);

    Task PlayCardAsync(Player player, Card card, CancellationToken cancellation);

    Task EndTurnAsync(Player player, CancellationToken cancellation);

    ValueTask<GameStats> GetStatsAsync(CancellationToken cancellation);
}