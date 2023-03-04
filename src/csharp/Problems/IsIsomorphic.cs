//https://leetcode.com/problems/isomorphic-strings/

namespace LeetCode.Problems;

public sealed class IsIsomorphic : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsIsomorphic))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("egg").Param("add").Result(true))
            .Add(it => it.Param("foo").Param("bar").Result(false))
            .Add(it => it.Param("paper").Param("title").Result(true));

    private bool Solution(string s, string t)
    {
        var map = new int[127, 2];
        for (var i = 0; i < s.Length; i++)
        {
            if (map[s[i], 0] != map[t[i], 1])
            {
                return false;
            }

            map[s[i], 0] = i + 1;
            map[t[i], 1] = i + 1;
        }

        return true;
    }
}