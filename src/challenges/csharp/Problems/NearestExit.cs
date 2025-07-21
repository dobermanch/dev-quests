// https://leetcode.com/problems/nearest-exit-from-entrance-in-maze

using System.Drawing;

namespace LeetCode.Problems;

public sealed class NearestExit : ProblemBase
{
    [Theory]
    [ClassData(typeof(NearestExit))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<char>("""[["+",".","+","+","+","+","+"],["+",".","+",".",".",".","+"],["+",".","+",".","+",".","+"],["+",".",".",".",".",".","+"],["+","+","+","+",".","+","."]]""").ParamArray("[0,1]").Result(7))
          .Add(it => it.Param2dArray<char>("""[['+','+','.','+'],['.','.','.','+'],['+','+','+','.']]""").ParamArray("[1,2]").Result(1))
          .Add(it => it.Param2dArray<char>("""[['+','+','+'],['.','.','.'],['+','+','+']]""").ParamArray("[1,0]").Result(2))
          .Add(it => it.Param2dArray<char>("""[[".","+","+","+","+"],[".","+",".",".","."],[".","+",".","+","."],[".",".",".","+","."],["+","+","+","+","."]]""").ParamArray("[0,0]").Result(1))
          .Add(it => it.Param2dArray<char>("""[['.','+']]""").ParamArray("[0,0]").Result(-1));

    private int Solution(char[][] maze, int[] entrance)
    {
        int[,] direction = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        var queue = new Queue<(int, int, int)>();

        queue.Enqueue((0, entrance[1], entrance[0]));
        while (queue.Count > 0)
        {
            var (count, x, y) = queue.Dequeue();

            if ((x == 0 || x == maze[0].Length - 1
                || y == 0 || y == maze.Length - 1)
                && (x != entrance[1] || y != entrance[0]))
            {
                return count;
            }

            for (var i = 0; i < direction.GetLength(0); i++)
            {
                var x1 = x + direction[i, 0];
                var y1 = y + direction[i, 1];
                if (x1 >= 0 && x1 < maze[0].Length
                    && y1 >= 0 && y1 < maze.Length
                    && maze[y1][x1] != '+')
                {
                    queue.Enqueue((count + 1, x1, y1));
                    maze[y1][x1] = '+';
                }
            }
        }

        return -1;
    }
}