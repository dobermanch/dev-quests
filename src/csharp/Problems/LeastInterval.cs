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
                .Select(it => (0, Count: it.Count()))
                .OrderByDescending(it => it.Count);

        var workQueue = new PriorityQueue<int, int>(map, Comparer<int>.Create((l, r) => r - l));
        var idleQueue = new Queue<(int count, int next)>();

        var time = 0;
        while (workQueue.Count > 0 || idleQueue.Any())
        {
            time++;
            if (workQueue.TryDequeue(out _, out var count) && count > 1)
            {
                idleQueue.Enqueue((--count, time + n));
            }

            if (idleQueue.Any() && idleQueue.Peek().next == time)
            {
                workQueue.Enqueue(0, idleQueue.Dequeue().count);
            }
        }

        return time;
    }
}