//https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal

namespace LeetCode.Problems;

public sealed class MakeEqual : ProblemBase
{
    [Theory]
    [ClassData(typeof(MakeEqual))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["abc","aabc","bc"]""").Result(true))
          .Add(it => it.ParamArray<string>("""["ab","a"]""").Result(false))
          .Add(it => it.ParamArray<string>("""["a","b"]""").Result(false))
          .Add(it => it.ParamArray<string>("""["b"]""").Result(true));

    private bool Solution(string[] words)
    {
        var map = new int[26];

        foreach (var word in words)
        {
            foreach (var ch in word)
            {
                map[ch - 'a']++;
            }
        }

        foreach (var count in map)
        {
            if (count % words.Length != 0)
            {
                return false;
            }
        }

        return true;
    }
}