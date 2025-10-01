namespace Snake.Game;

public sealed class SnakeGame
{
    private readonly Board _board;
    private readonly Snake _snake;
    private Direction _direction;

    public SnakeGame(int size)
    {
        _board = new Board(size);
        _snake = new Snake(_board[size / 2, size / 2]!);
        _snake.Head.Type = CellType.Snake;
        Status = new GameStatus(GameState.InProgress, 0);
        _direction = Direction.Right;
        SetFoodCell();
    }

    public GameStatus Status { get; private set; }

    public bool UpdateDirection(Direction direction)
    {
        if (_direction == Direction.Left && direction is Direction.Up or Direction.Down
            || _direction == Direction.Right && direction is Direction.Up or Direction.Down
            || _direction == Direction.Up && direction is Direction.Left or Direction.Right
            || _direction == Direction.Down && direction is Direction.Left or Direction.Right)
        {
            _direction = direction;
            return true;
        }

        return false;
    }

    public void GameLoop()
    {
        if (Status.State != GameState.InProgress)
        {
            throw new InvalidOperationException("Game has ended, start a new game");
        }

        (int x, int y) = GetNextPosition(_snake.Head, _direction);

        Cell? nextCell = _board[x, y];
        if (nextCell is null || nextCell.Type == CellType.Snake)
        {
            Status = Status with { State = GameState.GameOver };
            return;
        }

        if (nextCell.IsFoodCell)
        {
            GrowSnake(nextCell);
            return;
        }

        MoveSnake(nextCell);

        if (_snake.Length == _board.Cells.Length)
        {
            Status = new GameStatus(GameState.Win, Status.Score + 100);
        }
    }

    private void GrowSnake(Cell nextCell)
    {
        Status = Status with { Score = Status.Score + (int)nextCell.Type };

        _snake.Grow(nextCell);
        nextCell.Type = CellType.Snake;

        SetFoodCell();
    }

    private void SetFoodCell()
    {
        var foodSell = GetEmptyCell();
        if (foodSell is not null)
        {
            foodSell.Type = GetFoodType();
        }
    }

    private void MoveSnake(Cell nextCell)
    {
        Cell tail = _snake.Tail;

        _snake.Move(nextCell);
        nextCell.Type = CellType.Snake;

        tail.Type = CellType.Empty;
    }

    private static (int x, int y) GetNextPosition(Cell cell, Direction direction)
        => direction switch
        {
            Direction.Up => (cell.X, cell.Y - 1),
            Direction.Down => (cell.X, cell.Y + 1),
            Direction.Left => (cell.X - 1, cell.Y),
            Direction.Right => (cell.X + 1, cell.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    private Cell? GetEmptyCell()
    {
        var seen = new HashSet<(int, int)>();
        while (seen.Count < _board.Cells.Length)
        {
            var x = Random.Shared.Next(_board.Size);
            var y = Random.Shared.Next(_board.Size);
            if (!seen.Add((x, y)))
            {
                continue;
            }

            var candidate = _board.Cells[y, x];
            if (candidate.Type == CellType.Empty)
            {
                return candidate;
            }
        }

        return null;
    }

    private CellType GetFoodType()
    {
        var position = Random.Shared.Next(_board.Cells.Length);
        return position % 5 == 0 ? CellType.Pie : CellType.Apple;
    }
}
