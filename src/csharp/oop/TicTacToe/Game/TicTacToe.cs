namespace TicTacToe.Game;

public class TicTacToe
{
    private Board _board = new();
    private readonly List<Player> _players = new();
    private readonly ScoreBoard _scoreBoard = new();
    private Player? _currentPlayer;

    public GameStatus Status { get; private set; } = new(GameState.Idle);

    public void StartGame(Player player1, Player player2)
    {
        if (Status.Sate == GameState.Playing)
        {
            throw new InvalidOperationException("Game is already playing");
        }

        _board = new Board();
        _players.Clear();
        _players.Add(player1);
        _players.Add(player2);
        _currentPlayer = player1;
        Status = new(GameState.Playing);
    }

    public void MakeMove(Player player, int x, int y)
    {
        if (Status.Sate != GameState.Playing)
        {
            throw new InvalidOperationException("Start new game to continue");
        }

        if (player != _currentPlayer)
        {
            throw new InvalidOperationException(
                $"Wrong player. The '{_currentPlayer!.Value.Name}' player should make a move");
        }

        _board.UpdateBoard(player.Symbol, x, y);

        if (_board.IsWinner(player.Symbol, x, y))
        {
            _scoreBoard.RecordWin(player);
            _scoreBoard.RecordLoose(GetNextPlayer(player));
            Status = new(GameState.GameEnded) { Winner = player};
            return;
        }

        if (_board.IsDraw())
        {
            Status = new(GameState.GameEnded) {IsDraw = true};
            return;
        }

        _currentPlayer = GetNextPlayer(player);
    }

    public IReadOnlyCollection<ScoreRecord> GetScoreBoard()
        => _scoreBoard.GetScores();

    public ScoreRecord GetPlayerScore(Player player)
        => _scoreBoard.GetPlayerScore(player);

    private Player GetNextPlayer(Player player)
        => _players.First(it => it != player);
}
