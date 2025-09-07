namespace TicTacToe.Game;

public class Board
{
    private readonly char[][] _cells;
    private readonly int _size;
    private readonly int _winningLength;
    private int _leftMoves;

    public Board()
    {
        _size = 3;
        _winningLength = _size;
        _leftMoves = _size * _size;
        _cells = Enumerable.Range(1, _size).Select(it => Enumerable.Repeat('.', _size).ToArray()).ToArray();
    }

    public void UpdateBoard(char symbol, int x, int y)
    {
        if (x < 0 || x >= _size || y < 0 || y >= _size)
        {
            throw new ArgumentException($"The x:{x}, y:{y} outside of the game board");
        }

        if (_cells[x][y] != '.')
        {
            throw new InvalidOperationException($"The x:{x}, y:{y} cell already contains '{_cells[x][y]}'.");
        }

        _cells[x][y] = symbol;
        _leftMoves -= 1;
    }

    public bool IsDraw()
        => _leftMoves <= 0;

    public bool IsWinner(char symbol, int x, int y)
    {
        var countX = 0;
        var countY = 0;
        var diagL = 0;
        var diagR = 0;

        for (int i = 0; i < _size; i++)
        {
            if (_cells[x][i] == symbol)
            {
                countX += 1;
            }

            if (_cells[i][y] == symbol)
            {
                countY += 1;
            }

            if (_cells[i][i] == symbol)
            {
                diagL += 1;
            }

            if (_cells[_size - i - 1][i] == symbol)
            {
                diagR += 1;
            }
        }

        if (countX == _winningLength
            || countY == _winningLength
            || diagL == _winningLength
            || diagR == _winningLength)
        {
            return true;
        }

        return false;
    }
}
