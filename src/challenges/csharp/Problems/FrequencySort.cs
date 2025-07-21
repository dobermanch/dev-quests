//https://leetcode.com/problems/sort-characters-by-frequency/

namespace LeetCode.Problems;

public sealed class FrequencySort : ProblemBase
{
    [Theory]
    [ClassData(typeof(FrequencySort))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("tree").Result("eetr"))
          .Add(it => it.Param("cacacac").Result("ccccaaa"))
          .Add(it => it.Param("cacaca").Result("cccaaa"))
          .Add(it => it.Param("cccaaa").Result("cccaaa"))
          .Add(it => it.Param("Aabb").Result("bbAa"));

    private string Solution(string s)
    {
        var map = new Dictionary<char, int>();
        foreach (var ch in s)
        {
            map[ch] = map.GetValueOrDefault(ch, 0) + 1;
        }

        var queue = new PriorityQueue<char, int>(map.Select(it => (it.Key, -it.Value)));

        var result = new StringBuilder();
        while(queue.Count > 0)
        {
            queue.TryDequeue(out var letter, out var count);
            result.Append(letter, -count);
        }

        return result.ToString();
    }

    private string Solution1(string s)
    {
        var max = 0;
        var map = new Dictionary<char, int>();
        foreach (var ch in s)
        {
            map[ch] = map.GetValueOrDefault(ch, 0) + 1;
            max = Math.Max(max, map[ch]);
        }

        var buckets = new string?[max + 1];
        foreach (var ch in map)
        {
            buckets[ch.Value] += new string(ch.Key, ch.Value);
        }

        var result = new StringBuilder();
        for (var i = buckets.Length - 1; i >= 0; i--)
        {
            result.Append(buckets[i]);
        }

        return result.ToString();
    }
}