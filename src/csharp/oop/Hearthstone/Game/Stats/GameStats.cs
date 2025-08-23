using Hearthstone.Game.Players;

namespace Hearthstone.Game.Stats;

public sealed class GameStats
{
    private readonly DateTime _startedAt = DateTime.Now;
    private readonly List<PlayerMove> _moves = new ();

    public IReadOnlyList<PlayerMove> Moves => _moves.AsReadOnly();

    public GameStats(IList<Player> players)
    {
        if (players is null)
        {
            throw new ArgumentNullException(nameof(players));
        }

        Players = players.AsReadOnly(); 
    }

    public Player? Winner { get; private set; }

    public IReadOnlyCollection<Player> Players { get; }

    public TimeSpan GameDuration => DateTime.Now - _startedAt;

    public void RecordMove(PlayerMove move) => _moves.Add(move);

    public void SetWinner(Player winner) => Winner = winner;
}