//https://leetcode.com/problems/valid-anagram/

namespace LeetCode.Problems;

public sealed class IsAnagram : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsAnagram))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("anagram").Param("nagaram").Result(true))
          .Add(it => it.Param("anagram").Param("nagara").Result(false))
          .Add(it => it.Param("rat").Param("car").Result(false));

    private bool Solution(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var map = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
            map[s[i]] = map.GetValueOrDefault(s[i]) + 1;
            map[t[i]] = map.GetValueOrDefault(t[i]) - 1;
        }

        return map.All(it => it.Value == 0);
    }
}