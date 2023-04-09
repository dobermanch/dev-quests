//https://leetcode.com/problems/word-break/

namespace LeetCode.Problems;

public sealed class WordBreak : ProblemBase
{
    [Theory]
    [ClassData(typeof(WordBreak))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("leetcode").ParamArray<string>("""["leet","code"]""").Result(true))
          .Add(it => it.Param("applepenapple").ParamArray<string>("""["apple","pen"]""").Result(true))
          .Add(it => it.Param("catsandog").ParamArray<string>("""["cats","dog","sand","and","cat"]""").Result(false));

    private bool Solution(string s, IList<string> wordDict)
    {
        var map = new bool[s.Length+1];
        map[^1] = true;
        var mem = new List<int> {s.Length};
        for (var i = s.Length - 1; i >= 0; i--)
        {
            for (int j = mem.Count - 1; j >= 0; j--)
            {
                if (wordDict.Contains(s[i..mem[j]]))
                {
                    map[i] = map[mem[j]];
                    mem.Add(i);
                    break;
                }
            }
        }

        return map[0];
    }
}