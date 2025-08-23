//https://leetcode.com/problems/minimum-window-substring/

namespace LeetCode.Problems;

public sealed class MinWindow : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinWindow))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("ADOBECODEBANC").Param("ABC").Result("BANC"))
          .Add(it => it.Param("ADOBECODEBANC").Param("ABAC").Result("ADOBECODEBA"))
          .Add(it => it.Param("EDOCEBODEBAND").Param("ABC").Result("CEBODEBA"))
          .Add(it => it.Param("a").Param("a").Result("a"))
          .Add(it => it.Param("a").Param("aa").Result(""));

    private string Solution(string s, string t)
    {
        var map = new int[128, 2];
        foreach (var t1 in t)
        {
            map[t1, 0]++;
        }

        var left = 0;
        var matches = 0;
        var result = string.Empty;
        for (int right = 0; right < s.Length; right++)
        {
            map[s[right], 1]++;

            if (map[s[right], 0] >= map[s[right], 1])
            {
                matches++;
            }

            while (matches == t.Length)
            {
                if (right - left + 1 < result.Length || result.Length == 0)
                {
                    result = s.Substring(left, right - left + 1);
                }

                map[s[left], 1]--;
                if (map[s[left], 0] > map[s[left], 1])
                {
                    matches--;
                }

                left++;
            }
        }

        return result;
    }
}