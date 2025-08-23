namespace Hearthstone.Game.Players.Selectors;

public sealed class DefaultPlayerSelector : IPlayerSelector
{
    private readonly Random _random = new(DateTime.UtcNow.Microsecond);

    public Player Select(IList<Player> players)
    {
        if (players is null || players.Count <= 0)
        {
            throw new ArgumentException(nameof(players));
        }

        return players[_random.Next(0, players.Count - 1)];
    }
}
