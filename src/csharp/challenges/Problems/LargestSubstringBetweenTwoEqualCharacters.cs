//https://leetcode.com/problems/largest-substring-between-two-equal-characters

namespace LeetCode.Problems;

public sealed class MaxLengthBetweenEqualCharacters : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxLengthBetweenEqualCharacters))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("abcacca").Result(5))
          .Add(it => it.Param("aa").Result(0))
          .Add(it => it.Param("abca").Result(2))
          .Add(it => it.Param("cbzxy").Result(-1));

    private int Solution(string s)
    {
        var map = new Dictionary<char, int>();

        var result = -1;
        for (var i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
            {
                result = Math.Max(result, i - map[s[i]] - 1);
            }
            else
            {
                map[s[i]] = i;
            }
        }

        return result;
    }
}