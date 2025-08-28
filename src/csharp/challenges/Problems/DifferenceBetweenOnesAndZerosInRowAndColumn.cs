//https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column

namespace LeetCode.Problems;

public sealed class OnesMinusZeros : ProblemBase
{
    [Theory]
    [ClassData(typeof(OnesMinusZeros))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,1,1],[1,0,1],[0,0,1]]").Result2dArray("[[0,0,4],[0,0,4],[-2,-2,2]]"))
          .Add(it => it.Param2dArray("[[1,1,1],[1,1,1]]").Result2dArray("[[5,5,5],[5,5,5]]"));

    private int[][] Solution(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var rowMap = new int[rows];
        var colMap = new int[cols];

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (grid[row][col] == 1)
                {
                    rowMap[row]++;
                    colMap[col]++;
                }
            }
        }

        var result = new int[grid.Length][];
        for (var row = 0; row < rows; row++)
        {
            result[row] = new int[cols];
            for (var col = 0; col < cols; col++)
            {
                result[row][col] = rowMap[row] + colMap[col] - (rows - rowMap[row]) - (cols - colMap[col]);
            }
        }

        return result;
    }
}