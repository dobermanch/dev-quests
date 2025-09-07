namespace TicTacToe.Game;

public class ScoreBoard
{
    private readonly Dictionary<string, int> _scores = new();

    public void RecordWin(Player player)
    {
        _scores.TryAdd(player.Name, 0);
        _scores[player.Name] += 1;
    }

    public void RecordLoose(Player player)
    {
        _scores.TryAdd(player.Name, 0);
        _scores[player.Name] -= 1;
    }

    public ScoreRecord GetPlayerScore(Player player)
        => new (player.Name, _scores.GetValueOrDefault(player.Name, 0));

    public IReadOnlyCollection<ScoreRecord> GetScores()
        => _scores
            .Select(it => new ScoreRecord(it.Key, it.Value))
            .OrderByDescending(it => it.Score)
            .ToList();
}
