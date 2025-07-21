//https://leetcode.com/problems/word-pattern

namespace LeetCode.Problems;

public sealed class WordPattern : ProblemBase
{
    [Theory]
    [ClassData(typeof(WordPattern))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("abba").Param("dog cat cat dog").Result(true))
          .Add(it => it.Param("aaa").Param("aa aa aa aa").Result(false))
          .Add(it => it.Param("abc").Param("b c a").Result(true))
          .Add(it => it.Param("abc").Param("dog cat dog").Result(false))
          .Add(it => it.Param("abba").Param("dog dog dog dog").Result(false))
          .Add(it => it.Param("abba").Param("dog cat cat fish").Result(false))
          .Add(it => it.Param("aaaa").Param("dog cat cat dog").Result(false))
          .Add(it => it.Param("aaaa").Param("dog dog dog dog").Result(true));

    private bool Solution(string pattern, string s)
    {
        var words = s.Split(' ');
        if (words.Length != pattern.Length)
        {
            return false;
        }

        var map1 = new Dictionary<char, string>();
        var map2 = new Dictionary<string, char>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var pat = pattern[i];

            if (!map1.ContainsKey(pat) && !map2.ContainsKey(word))
            {
                map1[pat] = word;
                map2[word] = pat;
                continue;
            }

            if (!map1.TryGetValue(pat, out var value1)
             || value1 != word
             || !map2.TryGetValue(word, out var value2)
             || value2 != pat)
            {
                return false;
            }
        }

        return true;
    }
}