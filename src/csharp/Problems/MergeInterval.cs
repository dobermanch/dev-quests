//https://leetcode.com/problems/merge-intervals/

namespace LeetCode.Problems;

public sealed class MergeInterval : ProblemBase
{
    [Theory]
    [ClassData(typeof(MergeInterval))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,3],[2,6],[8,10],[15,18]]").Result2dArray("[[1,6],[8,10],[15,18]]"))
          .Add(it => it.Param2dArray("[[1,4],[4,5]]").Result2dArray("[[1,5]]"))
          .Add(it => it.Param2dArray("[[1,6],[4,5]]").Result2dArray("[[1,6]]"))
          .Add(it => it.Param2dArray("[[1,4],[0,0]]").Result2dArray("[[0,0],[1,4]]"));

    private int[][] Solution(int[][] intervals)
    {
        var result = new List<int[]>();

        Array.Sort(intervals, (x, y) => x[0] - y[0]);

        var merge = intervals[0];
        foreach (var interval in intervals)
        {
            if (merge[1] >= interval[0])
            {
                merge[1] = Math.Max(merge[1], interval[1]);
            }
            else
            {
                result.Add(merge);
                merge = interval;
            }
        }

        result.Add(merge);

        return result.ToArray();
    }
}