//https://leetcode.com/problems/task-scheduler/

namespace LeetCode.Problems;

public sealed class LeastInterval : ProblemBase
{
    [Theory]
    [ClassData(typeof(LeastInterval))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray<char>("""["A","A","A","B","B","B"]""").Param(2).Result(8))
          .Add(it => it.ParamArray<char>("""["A","A","A","B","B","B"]""").Param(0).Result(6))
          .Add(it => it.ParamArray<char>("[]").Param(3).Result(0))
          .Add(it => it.ParamArray<char>("""["A","A","A","A","A","A","B","C","D","E","F","G"]""").Param(2).Result(16))
          .Add(it => it.ParamArray<char>("""["A","A","A","B","B","B","C","C","C","D","D","E"]""").Param(2).Result(12))
          .Add(it => it.ParamArray<char>("""["A","A","A","B","B","B","C","C","D","D","F","F"]""").Param(2).Result(12))
          .Add(it => it.ParamArray<char>("""["A","A","A","A","A","B","B","B","C","C","C","D","D"]""").Param(2).Result(13));

    private int Solution(char[]? tasks, int n)
    {
        if (n == 0 || tasks == null || tasks.Length == 0)
        {
            return tasks?.Length ?? 0;
        }

        var map = tasks
                .GroupBy(it => it)
                .Select(it => (it.Key, Count: it.Count()))
                .OrderByDescending(it => it.Count);

        var workQueue = new PriorityQueue<char, int>(map, Comparer<int>.Create((l, r) => r - l));

        var units = 0;
        while(workQueue.Count > 0)
        {
            var idleQueue = new List<(char, int)>();
            var idle = n + 1;
            var tasksCount = workQueue.Count;

            for (int i = 0; i < tasksCount; i++)
            {
                if (workQueue.TryDequeue(out var task, out var count) && count > 0)
                {
                    units++;
                    idle--;
                    if (--count > 0)
                    {
                        idleQueue.Add((task, count));
                    }
                }

                if (idle == 0)
                {
                    break;
                }
            }

            workQueue.EnqueueRange(idleQueue);
            if (workQueue.Count > 0)
            {
                units += idle;
            }
        }

        return units;
    }
}