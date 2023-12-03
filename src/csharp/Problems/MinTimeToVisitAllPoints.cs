//https://leetcode.com/problems/minimum-time-visiting-all-points

namespace LeetCode.Problems;

public sealed class MinTimeToVisitAllPoints : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinTimeToVisitAllPoints))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1],[3,4],[-1,0]]").Result(7))
          .Add(it => it.Param2dArray("[[3,2],[-2,2]]").Result(5));

    private int Solution(int[][] points) 
    {
        var result = 0;
        for (var i = 1; i < points.Length; i++)
        {
            result += Math.Max(
                Math.Abs(points[i - 1][0] - points[i][0]), 
                Math.Abs(points[i - 1][1] - points[i][1]));
        }

        return result;
    }
}