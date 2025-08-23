//https://leetcode.com/problems/surrounded-regions

namespace LeetCode.Problems;

public sealed class Solve : ProblemBase
{
    [Theory]
    [ClassData(typeof(Solve))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<char>("""[['X','X','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','O','X']]""").Result2dArray<char>("""[['X','X','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','O','X']]"""))
          .Add(it => it.Param2dArray<char>("""[['X','X','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','X','X']]""").Result2dArray<char>("""[['X','X','X','X'],['X','X','X','X'],['X','X','X','X'],['X','O','X','X']]"""))
          .Add(it => it.Param2dArray<char>("""[['X']]""").Result2dArray<char>("""[['X']]"""));

    private char[][] Solution(char[][] board)
    {
        void Mark(char[][] board, int y, int x)
        {
            if (y < 0 || y >= board.Length
                || x < 0 || x >= board[0].Length
                || board[y][x] != 'O')
            {
                return;
            }

            board[y][x] = 'o';

            Mark(board, y + 1, x);
            Mark(board, y - 1, x);
            Mark(board, y, x + 1);
            Mark(board, y, x - 1);
        }

        var rows = board.Length;
        var cols = board[0].Length;

        for (var col = 0; col < cols; col++)
        {
            Mark(board, 0, col);
            Mark(board, rows - 1, col);
        }

        for (var row = 0; row < rows; row++)
        {
            Mark(board, row, 0);
            Mark(board, row, cols - 1);
        }

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                board[row][col] = board[row][col] == 'o' ? 'O' : 'X';
            }
        }

        return board;
    }
}