//https://leetcode.com/problems/pascals-triangle

namespace LeetCode.Problems;

public sealed class PascalsTriangle : ProblemBase
{
    [Theory]
    [ClassData(typeof(PascalsTriangle))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(5).Result2dArray("[[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]"))
          .Add(it => it.Param(1).Result2dArray("[[1]]"));

    private int[][] Solution(int numRows)
    {
        var result = Enumerable.Range(1, numRows).Select(it => new int[it]).ToArray();

        for (var i = 0; i < result.Length; i++)
        {
            for (var j = 0; j < result[i].Length; j++)
            {
                if (j == 0 || j == result[i].Length - 1)
                {
                    result[i][j] = 1;
                }
                else if (i > 0)
                {
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }
        }

        return result;
    }
}