//https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended-ii/

namespace LeetCode.Problems;

public sealed class MaxValue : ProblemBase
{
    //[Theory]
    //[ClassData(typeof(MaxValue))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,4],[3,4,3],[2,3,1]]").Param(2).Result(7))
          .Add(it => it.Param2dArray("[[1,2,4],[3,4,3],[2,3,10]]").Param(2).Result(10))
          .Add(it => it.Param2dArray("[[1,1,1],[2,2,2],[3,3,3],[4,4,4]]").Param(3).Result(9));

    private int Solution(int[][] events, int k)
    {
        Array.Sort(events, (left, right) => left[0] - right[0]);

        int GetNextInterval(int startAt, int target)
        {
            var left = startAt;
            var right = events.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (events[mid][0] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        var map = new int[events.Length + 1];
        for (int i = events.Length - 1; i >= 0; i--)
        {
            map[i] = Math.Max(map[i + 1], events[i][2]);

            var next = GetNextInterval(i, events[i][1]);
            map[i] = Math.Max(map[i], events[i][2] + map[next]);
        }

        return map[0];
    }
}