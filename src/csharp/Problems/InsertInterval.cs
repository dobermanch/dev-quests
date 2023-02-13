//https://leetcode.com/problems/insert-interval/

namespace LeetCode.Problems;

public sealed class InsertInterval : ProblemBase
{
    [Theory]
    [ClassData(typeof(InsertInterval))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[3,6],[9,9],[11,13],[14,14],[16,19],[20,22],[23,25],[30,34],[41,43],[45,49]]").ParamArray("[29,32]").Result2dArray("[[3,6],[9,9],[11,13],[14,14],[16,19],[20,22],[23,25],[29,34],[41,43],[45,49]]"))
          .Add(it => it.Param2dArray("[[0,5],[9,12]]").ParamArray("[7,16]").Result2dArray("[[0,5],[7,16]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[0,7]").Result2dArray("[[0,7]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[0,3]").Result2dArray("[[0,5]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[2,7]").Result2dArray("[[1,7]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[2,3]").Result2dArray("[[1,5]]"))
          .Add(it => it.Param2dArray("[[1,2],[3,5],[6,7],[8,10],[12,16]]").ParamArray("[4,8]").Result2dArray("[[1,2],[3,10],[12,16]]"))
          .Add(it => it.Param2dArray("[[1,3],[6,9]]").ParamArray("[2,5]").Result2dArray("[[1,5],[6,9]]"))
          .Add(it => it.Param2dArray("[]").ParamArray("[2,5]").Result2dArray("[[2,5]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[0,0]").Result2dArray("[[0,0],[1,5]]"))
          .Add(it => it.Param2dArray("[[1,5]]").ParamArray("[6,8]").Result2dArray("[[1,5],[6,8]]"))
          .Add(it => it.Param2dArray("[[1,3],[6,8]").ParamArray("[4,5]").Result2dArray("[[1,3],[4,5],[6,8]]"));

    private int[][] Solution(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        int[]? merged = null;
        for (var i = 0; i < intervals.Length; i++)
        {
            if (merged == null && newInterval[0] <= intervals[i][1])
            {
                merged = new[] { Math.Min(intervals[i][0], newInterval[0]), newInterval[1] };
            }
            else if (intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
            }

            if (newInterval[1] < intervals[i][0])
            {
                result.Add(merged!);
                result.AddRange(intervals[i..]);
                return result.ToArray();
            }

            if (newInterval[1] <= intervals[i][1])
            {
                merged![1] = Math.Max(intervals[i][1], newInterval[1]);
                result.Add(merged);
                result.AddRange(intervals[(i + 1)..]);
                return result.ToArray();
            }
        }

        result.Add(merged ?? newInterval);

        return result.ToArray();
    }
}