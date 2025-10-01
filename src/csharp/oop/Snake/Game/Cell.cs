namespace Snake.Game;

public record Cell(int X, int Y)
{
    public CellType Type { get; set; }

    public bool IsFoodCell =>  Type is CellType.Apple or CellType.Pie;
}
