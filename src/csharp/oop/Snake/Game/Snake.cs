namespace Snake.Game;

public sealed class Snake(Cell cell)
{
    private readonly LinkedList<Cell> _body = new([cell]);

    public Cell Head => _body.First!.Value;

    public Cell Tail => _body.Last!.Value;

    public int Length => _body.Count;

    public void Move(Cell cell)
    {
        _body.AddFirst(cell);
        _body.RemoveLast();
    }

    public void Grow(Cell cell)
    {
        _body.AddFirst(cell);
    }
}
