//https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points

namespace LeetCode.Problems;

public sealed class MaxWidthOfVerticalArea : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxWidthOfVerticalArea))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[8,7],[9,9],[7,4],[9,7]]").Result(1))
          .Add(it => it.Param2dArray("[[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]").Result(3));

    private int Solution(int[][] points)
    {
        Array.Sort(points, (left, right) => left[0] - right[0]);

        var max = 0;
        for (var i = 1; i < points.Length; i++)
        {
            max = Math.Max(max, points[i][0] - points[i - 1][0]);
        }

        return max;
    }
}