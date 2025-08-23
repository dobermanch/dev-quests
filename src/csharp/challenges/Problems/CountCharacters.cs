//https://leetcode.com/problems/find-words-that-can-be-formed-by-characters

namespace LeetCode.Problems;

public sealed class CountCharacters : ProblemBase
{
    [Theory]
    [ClassData(typeof(CountCharacters))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["cat","bt","hat","tree"]""").Param("atachz").Result(6))
          .Add(it => it.ParamArray<string>("""["hello","world","leetcode"]""").Param("welldonehoneyr").Result(10));

    private int Solution(string[] words, string chars)
    {
        var map = new int[26];
        foreach (var ch in chars)
        {
            map[ch - 'a']++;
        }

        var result = 0;
        foreach (var word in words)
        {
            var wordMap = new int[26];
            var matched = true;

            foreach (var ch in word)
            {
                wordMap[ch - 'a']++;

                if (wordMap[ch - 'a'] > map[ch - 'a'])
                {
                    matched = false;
                    break;
                }
            }

            if (matched)
            {
                result += word.Length;
            }
        }

        return result;
    }
}