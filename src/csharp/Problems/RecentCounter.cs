//https://leetcode.com/problems/number-of-recent-calls/

namespace LeetCode.Problems;

public sealed class RecentCounter : ProblemBase
{
    [Theory]
    [ClassData(typeof(RecentCounter))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray<int>("[[], [1], [100], [3001], [3002]]", true)
                       .ParamArray<string>("""["RecentCounter", "ping", "ping", "ping", "ping"]""")
                       .ResultArray<int?>("[null, 1, 2, 3, 3]"));

    private IList<int?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<int?>();

        var obj = new CustomRecentCounter();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "RecentCounter":
                    result.Add(null);
                    break;
                case "ping":
                    result.Add(obj.Ping(data[i][0]));
                    break;
            }
        }

        return result;
    }

    public class CustomRecentCounter
    {
        private Queue<int> _queue = new();

        public int Ping(int t) 
        {
            _queue.Enqueue(t);

            while(_queue.Count > 0 && _queue.Peek() < (t - 3000)) 
            {
                _queue.Dequeue();
            }

            return _queue.Count;
        }
    }
}