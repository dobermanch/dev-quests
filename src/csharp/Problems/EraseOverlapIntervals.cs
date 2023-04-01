//https://leetcode.com/problems/non-overlapping-intervals/

namespace LeetCode.Problems;

public sealed class EraseOverlapIntervals : ProblemBase
{
    [Theory]
    [ClassData(typeof(EraseOverlapIntervals))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2],[2,3],[3,4],[1,3]]").Result(1))
          .Add(it => it.Param2dArray("[[1,2],[1,2],[1,2]]").Result(2))
          .Add(it => it.Param2dArray("[[1,2],[2,3]]").Result(0));

    private int Solution(int[][] intervals)
    {
        var result = 0;
        Array.Sort(intervals, (x, y) =>  x[0] - y[0]);

        var current = intervals[0];
        for (var i = 1; i < intervals.Length; i++)
        {
            if (current[1] > intervals[i][0])
            {
                result++;
                current = current[1] <= intervals[i][1] ? current : intervals[i];
            }
            else
            {
                current = intervals[i];
            }
        }

        return result;
    }
}