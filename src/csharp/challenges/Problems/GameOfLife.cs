// https://leetcode.com/problems/game-of-life

namespace LeetCode.Problems;

public sealed class GameOfLife : ProblemBase
{
    [Theory]
    [ClassData(typeof(GameOfLife))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]").Result2dArray("[[0,0,0],[1,0,1],[0,1,1],[0,1,0]]"))
          .Add(it => it.Param2dArray("[[1,1],[1,0]]").Result2dArray("[[1,1],[1,1]]"));

    private int[][] Solution(int[][] board)
    {
        int[,] directions = {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            {  0, -1 },            {  0, 1 },
            {  1, -1 }, {  1, 0 }, {  1, 1 }
        };

        var count = directions.GetLength(0);
        var rows = board.Length;
        var cols = board[0].Length;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var neighbors = 0;

                for (var i = 0; i < count; i++)
                {
                    var y = row + directions[i, 0];
                    var x = col + directions[i, 1];

                    if (y >= 0 && y < rows
                        && x >= 0 && x < cols
                        && (board[y][x] == 1 || board[y][x] >= 20))
                    {
                        neighbors++;
                    }
                }

                board[row][col] = neighbors + (board[row][col] == 0 ? 10 : 20);
            }
        }

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var neighbors = board[row][col] - (board[row][col] >= 20 ? 20 : 10);
                if (neighbors < 2 || neighbors > 3)
                {
                    board[row][col] = 0;
                }
                else if (neighbors == 3 && board[row][col] < 20)
                {
                    board[row][col] = 1;
                }
                else if (neighbors == 2 || neighbors == 3)
                {
                    board[row][col] = board[row][col] >= 20 ? 1 : 0;
                }
            }
        }

        return board;
    }
}