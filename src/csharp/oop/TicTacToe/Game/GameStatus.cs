namespace TicTacToe.Game;

public readonly record struct GameStatus(GameState Sate)
{
    public Player? Winner { get; init; }
    public bool IsDraw { get; init; }
}
