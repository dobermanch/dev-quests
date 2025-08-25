// https://leetcode.com/problems/find-right-interval

namespace LeetCode.Problems;

public class FindRightInterval : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindRightInterval))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,12],[2,9],[3,10],[13,14],[15,16],[16,17]]").ResultArray([3, 3, 3, 4, 5, -1]))
          .Add(it => it.Param2dArray("[[1,2],[2,3],[0,1],[3,4]]").ResultArray([1, 3, 0, -1]))
          .Add(it => it.Param2dArray("[[1,2]]").ResultArray([-1]))
          .Add(it => it.Param2dArray("[[4,4]]").ResultArray([0]))
          .Add(it => it.Param2dArray("[[3,4],[2,3],[1,2]]").ResultArray([-1, 0, 1]))
          .Add(it => it.Param2dArray("[[1,4],[2,3],[3,4]]").ResultArray([-1, 2, -1]));

    public int[] Solution(int[][] intervals)
    {
        var sortedIntervals = intervals
            .Select((it, i) => new[] { it[0], i })
            .OrderBy(it => it[0])
            .ToArray();

        var result = new int[intervals.Length];
        for (var index = 0; index < intervals.Length; index++)
        {
            int left = 0;
            int right = intervals.Length - 1;

            int target = intervals[index][1];
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (sortedIntervals[mid][0] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            result[index] = left >= 0 && left < intervals.Length ? sortedIntervals[left][1] : -1;
        }

        return result;
    }
}