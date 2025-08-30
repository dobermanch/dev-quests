
// https://leetcode.com/problems/unique-paths-ii

namespace LeetCode.Problems;

public sealed class UniquePathsIi : ProblemBase
{
    [Theory]
    [ClassData(typeof(UniquePathsIi))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,0,0],[0,1,0],[0,0,0]]").Result(2))
          .Add(it => it.Param2dArray("[[0,1],[0,0]]").Result(1))
          .Add(it => it.Param2dArray("[[0,0,0,0],[0,1,0,0],[0,0,0,0],[0,0,0,0]]").Result(8))
          .Add(it => it.Param2dArray("[[1]]").Result(0))
          .Add(it => it.Param2dArray("[[0]]").Result(1))
        ;

    private int Solution(int[][] obstacleGrid)
    {
        var width = obstacleGrid.Length;
        var height = obstacleGrid[0].Length;

        for (var row = 0; row < width; row++)
        {
            for (var col = 0; col < height; col++)
            {
                if (obstacleGrid[row][col] == 1)
                {
                    obstacleGrid[row][col] = 0;
                    continue;
                }
                
                if (row == 0 && col == 0)
                {
                    obstacleGrid[row][col] = 1;
                    continue;
                }

                if (row - 1 >= 0)
                {
                    obstacleGrid[row][col] += obstacleGrid[row - 1][col];
                }

                if (col - 1 >= 0)
                {
                    obstacleGrid[row][col] += obstacleGrid[row][col - 1];
                }
            }
        }

        return obstacleGrid[width - 1][height - 1];
    }
}
