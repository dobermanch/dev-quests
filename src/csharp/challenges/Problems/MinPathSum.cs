//https://leetcode.com/problems/minimum-path-sum

namespace LeetCode.Problems;

public sealed class MinPathSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinPathSum))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,3,1],[1,5,1],[4,2,1]]").Result(7))
          .Add(it => it.Param2dArray("[[1,2,3],[4,5,6]]").Result(12));

    private int Solution(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;

        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                if (row == 0 && col == 0)
                {
                    continue;
                }

                var top = row > 0 ? grid[row][col] + grid[row - 1][col] : int.MaxValue;
                var left = col > 0 ? grid[row][col] + grid[row][col - 1] : int.MaxValue;

                grid[row][col] = Math.Min(left, top);
            }
        }

        return grid[^1][^1];
    }
}