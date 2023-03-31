//https://leetcode.com/problems/add-two-integers/

namespace LeetCode.Problems;

public sealed class IsAnagram : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsAnagram))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
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
            if (!map.ContainsKey(s[i]))
            {
                map.Add(s[i], 0);
            }

            map[s[i]]++;

            if (!map.ContainsKey(t[i]))
            {
                map.Add(t[i], 0);
            }

            map[t[i]]--;
        }

        return map.All(it => it.Value == 0);
    }
}