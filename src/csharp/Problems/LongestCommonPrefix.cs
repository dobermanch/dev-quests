//https://leetcode.com/problems/longest-common-prefix

namespace LeetCode.Problems;

public sealed class LongestCommonPrefix : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestCommonPrefix))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["flower", "flow", "flight"]""").Result("fl"))
          .Add(it => it.ParamArray<string>("""["dog","racecar","car"]""").Result(""))
          .Add(it => it.ParamArray<string>("""["cir","car"]""").Result("c"))
        ;

    private string? Solution(string[] strs)
    {
        var map = new Dictionary<string, int>();

        var minLength = strs[0].Length;
        for (var i = 0; i < strs.Length; i++)
        {
            minLength = Math.Min(minLength, strs[i].Length);
            if (minLength == 0)
            {
                return string.Empty;
            }

            string? prefix = null;
            for (var j = 0; j < minLength; j++)
            {
                prefix += strs[i][j];
                if (!map.ContainsKey(prefix))
                {
                    map.Add(prefix, 0);
                }

                map[prefix]++;
            }
        }

        var keys = map.Where(it => it.Value == strs.Length).Select(it => it.Key).ToArray();
        return keys.Length == 0 ? string.Empty : keys.MaxBy(it => it.Length);
    }
}