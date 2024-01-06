//https://leetcode.com/problems/maximum-profit-in-job-scheduling

namespace LeetCode.Problems;

public sealed class JobScheduling : ProblemBase
{
    [Theory]
    [ClassData(typeof(JobScheduling))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[6,24,45,27,13,43,47,36,14,11,11,12]").ParamArray("[31,27,48,46,44,46,50,49,24,42,13,27]").ParamArray("[14,4,16,12,20,3,18,6,9,1,2,8]").Result(45))
          .Add(it => it.ParamArray("[1,2,3,3]").ParamArray("[3,4,5,6]").ParamArray("[50,10,40,70]").Result(120))
          .Add(it => it.ParamArray("[1,2,3,4,6]").ParamArray("[3,5,10,6,9]").ParamArray("[20,20,100,70,60]").Result(150))
          .Add(it => it.ParamArray("[1,1,1]").ParamArray("[2,3,4]").ParamArray("[5,6,4]").Result(6));

    private int Solution(int[] startTime, int[] endTime, int[] profit)
    {
        var schedule = Enumerable.Range(0, startTime.Length)
            .Select(it => (Start: startTime[it], End: endTime[it], Profit: profit[it]))
            .ToArray();

        Array.Sort(schedule, (left, right) => left.Start - right.Start);

        int GetNextInterval(int startAt, int target)
        {
            var left = startAt;
            var right = schedule.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (schedule[mid].Start < target)
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

        var map = new int[schedule.Length + 1];
        for (int i = schedule.Length - 1; i >= 0; i--)
        {
            map[i] = Math.Max(map[i + 1], schedule[i].Profit);

            var next = GetNextInterval(i, schedule[i].End);
            map[i] = Math.Max(map[i], schedule[i].Profit + map[next]);
        }

        return map[0];
    }
}