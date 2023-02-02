//https://leetcode.com/problems/sort-list/

namespace LeetCode.Problems;

public sealed class LongestPalindromeByConcat2Letter : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestPalindromeByConcat2Letter))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("lc","cl","gg").Result(6))
          .Add(it => it.ParamArray("ab", "ty", "yt", "lc", "cl", "ab").Result(8))
          .Add(it => it.ParamArray("cc", "ll", "xx", "cc", "cc", "xx").Result(10))
          .Add(it => it.ParamArray("cc", "ll", "xx").Result(2))
          .Add(it => it.ParamArray("qo", "fo", "fq", "qf", "fo", "ff", "qq", "qf", "of", "of", "oo", "of", "of", "qf", "qf", "of").Result(14))
          .Add(it => it.ParamArray("nt", "tt", "yt", "yn", "yy", "yn", "nt", "yn", "nt", "yy", "ny", "yn", "ny", "nn", "nn", "yy", "nn", "yt", "yn", "tn", "yy", "yn", "nt", "tt", "yn", "ny", "nn", "yn", "nn", "nt", "ny", "ty", "ny", "nt", "ny", "tn", "nt", "yy", "nn", "yy", "nn", "yt", "yy", "yn", "nn", "ny", "ty", "nn", "nt", "nt", "ny", "yy", "tn", "yy", "tn", "ty", "ny", "nt", "ty", "yt", "yn", "nn", "ny", "yt", "nt", "tt", "nt", "yy", "yt", "nt", "tt", "yn", "tn", "tn", "nt", "yt", "yn", "ty", "yy", "ty", "tn", "tn", "yn", "ty", "ty", "tn", "nn", "nt", "nn", "nn", "tt", "yy", "ty", "ny", "yy", "ny").Result(170))
          ;

    private int Solution1(string[] words)
    {
        var map = new int [26, 26];
        var sum = 0;
        var accum = 0;
        var palSum = 0;
        for (int i = 0; i < words.Length; i++)
        {
            var a1 = words[i][0] - 'a';
            var a2 = words[i][1] - 'a';

            map[a1, a2]++;

            if (a1 == a2)
            {
                if (map[a1, a2] % 2 != 0)
                {
                    accum += 1;
                }
                else
                {
                    palSum += 2;
                    accum--;
                }
            }
            else if (map[a1, a2] <= map[a2, a1])
            {
                sum += 4;
            }
        }

        if (palSum % 2 == 0)
        {
            palSum += accum > 0 ? 1 : 0;
        }

        sum += palSum * 2;

        return sum;
    }

    private int Solution(string[] words)
    {
        var map = new Dictionary<string, int>();
        var sum = 0;
        var accum = 0;
        var polSum = 0;
        for (var i = 0; i < words.Length; i++)
        {
            if (!map.ContainsKey(words[i]))
            {
                map.Add(words[i], 0);
            }

            map[words[i]]++;

            if (words[i][0] == words[i][1])
            {
                if (map[words[i]] % 2 != 0)
                {
                    accum += 1;
                }
                else
                {
                    polSum += 2;
                    accum--;
                }
            }
            else
            {
                var reverse = new string(words[i].Reverse().ToArray());
                if (map.ContainsKey(reverse) && map[words[i]] <= map[reverse])
                {
                    sum += 4;
                }
            }
        }

        if (polSum % 2 == 0)
        {
            polSum += accum > 0 ? 1 : 0;
        }

        sum += polSum * 2;

        return sum;
    }
}