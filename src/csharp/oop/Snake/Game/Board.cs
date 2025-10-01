namespace Snake.Game;

public sealed class Board
{
    public Board(int size)
    {
        Size = size;
        Cells = new Cell[size, size];

        for (var y = 0; y < size; y++)
        {
            for (var x = 0; x < size; x++)
            {
                Cells[y, x] = new Cell(x, y);
            }
        }
    }

    public Cell[,] Cells { get; }

    public int Size { get; }

    public Cell? this[int x, int y]
        => x < 0 || x >= Size || y < 0 || y >= Size ? null : Cells[y, x];
}
