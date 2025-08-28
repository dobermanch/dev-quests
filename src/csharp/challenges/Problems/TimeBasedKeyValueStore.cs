//https://leetcode.com/problems/time-based-key-value-store/

namespace LeetCode.Problems;

public sealed class TimeMap : ProblemBase
{
    [Theory]
    [ClassData(typeof(TimeMap))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<CustomTimeMap, object[]>(config =>
                config
                    .MapConstructor("TimeMap")
                    .MapInstruction("set", (it, data) => it.Set((string)data[0], (string)data[1], (int)data[2]))
                    .MapInstruction("get", (it, data) => it.Get((string)data[0], (int)data[1]))
           )
          .Add(it => it.Data<object>("""[[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]""")
                       .Instructions("""["TimeMap","set","get","get","set","get","get"]""")
                       .Output("""[null, null, "bar", "bar", null, "bar2", "bar2"]"""))
          .Add(it => it.Data<object>("""[[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]""")
                       .Instructions("""["TimeMap","set","set","get","get","get","get","get"]""")
                       .ResultArray<object?>(null, null, null, "", "high", "high", "low", "low"));

    public class CustomTimeMap
    {
        private readonly Dictionary<string, IList<(int time, string value)>> _map = new();

        public void Set(string key, string value, int timestamp)
        {
            if (!_map.ContainsKey(key))
            {
                _map[key] = new List<(int, string)>();
            }

            _map[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!_map.ContainsKey(key))
            {
                return string.Empty;
            }

            var list = _map[key];
            var left = 0;
            var right = list.Count - 1;

            while (left <= right)
            {
                var mid = (right + left) / 2;
                if (list[mid].time == timestamp)
                {
                    return list[mid].value;
                }

                if (list[mid].time <= timestamp)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left == 0 ? string.Empty : list[left - 1].value;
        }
    }
}