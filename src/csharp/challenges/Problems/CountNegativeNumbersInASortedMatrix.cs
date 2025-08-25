// https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix


namespace LeetCode.Problems;

public sealed class CountNegativeNumbersInASortedMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(CountNegativeNumbersInASortedMatrix))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]").Result(8))
          .Add(it => it.Param2dArray("[[3,2],[1,0]]").Result(0))
          .Add(it => it.Param2dArray("[[3,2],[-3,-3],[-3,-3],[-3,-3]]").Result(6));

    private int Solution(int[][] grid)
    {
        var result = 0;
        var height = grid.Length;
        var width = grid[0].Length;

        for (var row = 0; row < height; row++)
        {
            for (var col = width - 1; col >= 0; col--)
            {
                if (grid[row][col] < 0)
                {
                    result += height - row;
                    width = col;
                }
                else
                {
                    width = col + 1;
                    break;
                }
            }

        }

        return result;
    }
}