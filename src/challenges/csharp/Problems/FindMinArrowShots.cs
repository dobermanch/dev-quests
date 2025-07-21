//https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons

namespace LeetCode.Problems;

public sealed class FindMinArrowShots : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMinArrowShots))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[10,16],[2,8],[1,6],[7,12]]").Result(2))
          .Add(it => it.Param2dArray("[[9,12],[1,10],[4,11],[8,12],[3,9],[6,9],[6,7]]").Result(2))
          .Add(it => it.Param2dArray("[[3,9],[7,12],[3,8],[6,8],[9,10],[2,9],[0,9],[3,9],[0,6],[2,8]]").Result(2))
          .Add(it => it.Param2dArray("[[-2147483646,-2147483645],[2147483646,2147483647]]").Result(2))
          .Add(it => it.Param2dArray("[[1,2],[3,4],[5,6],[7,8]]").Result(4))
          .Add(it => it.Param2dArray("[[1,2],[2,3],[3,4],[4,5]]").Result(2))
          .Add(it => it.Param2dArray("[[1,2]]").Result(1))
          .Add(it => it.Param2dArray("[[2,3],[2,3]]").Result(1));

    private int Solution1(int[][] points)
    {
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));

        var result = 1;
        var end = points[0][1];
        for (int i = 1; i < points.Length; i++)
        {
            if (end < points[i][0])
            {
                end = points[i][1];
                result++;
            }
        }

        return result;
    }

    private int Solution2(int[][] points)
    {
        Array.Sort(points, (x, y) => x[0].CompareTo(y[0]));

        var result = 1;
        var end = points[0][1];
        for (int i = 1; i < points.Length; i++)
        {
            if (end >= points[i][0])
            {
                end = Math.Min(end, points[i][1]);
            }
            else
            {
                result++;
                end = points[i][1];
            }
        }

        return result;
    }
}