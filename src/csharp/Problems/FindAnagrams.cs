//https://leetcode.com/problems/find-all-anagrams-in-a-string/

namespace LeetCode.Problems;

public sealed class FindAnagrams : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindAnagrams))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("cbaebabacd").Param("abc").ResultArray("[0,6]"))
            .Add(it => it.Param("abab").Param("ab").ResultArray("[0,1,2]"));

    private IList<int> Solution(string s, string p)
    {
        if (p.Length > s.Length)
        {
            return Array.Empty<int>();
        }

        var anagram = new int[26];
        foreach (var t in p)
        {
            anagram[t - 'a']++;
        }

        var result = new List<int>();
        var temp = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            temp[s[i] - 'a']++;

            if (i >= p.Length - 1)
            {
                var index = i - (p.Length - 1);
                if (anagram.SequenceEqual(temp))
                {
                    result.Add(index);
                }

                temp[s[index] - 'a']--;
            }
        }

        return result;
    }

    private IList<int> Solution1(string s, string p)
    {
        if (p.Length > s.Length)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();
        var map = new int[26];
        foreach (var t in p)
        {
            map[t - 'a'] += 1;
        }

        var lenght1 = s.Length - p.Length;
        for (var i = 0; i <= lenght1; i++)
        {
            if (map[s[i] - 'a'] <= 0)
            {
                continue;
            }

            var temp = map.ToArray();
            var count = 0;
            for (var j = i; j < i + p.Length; j++)
            {
                if (--temp[s[j] - 'a'] < 0)
                {
                    break;
                }
                count++;
            }

            if (count == p.Length)
            {
                result.Add(i);
            }
        }

        return result;
    }
}