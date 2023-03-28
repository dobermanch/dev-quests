//https://leetcode.com/problems/repeated-dna-sequences/

namespace LeetCode.Problems;

public sealed class FindRepeatedDnaSequences : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindRepeatedDnaSequences))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT").ResultArray<string>("""["AAAAACCCCC","CCCCCAAAAA"]"""))
          .Add(it => it.Param("AAAAAAAAAA").ResultArray<string>("""[]"""))
          .Add(it => it.Param("AAAAAAAAAAAAA").ResultArray<string>("""["AAAAAAAAAA"]"""))
          .Add(it => it.Param("AAAAAAAAA").ResultArray<string>("""[]"""));

    private IList<string> Solution(string s)
    {
        var window = 10;
        if (s.Length < window)
        {
            return Array.Empty<string>();
        }

        var hashMap = new Dictionary<char, int>
        {
            {'A',1},{'C',2},{'G',3},{'T',4}
        };

        var prime = 5;
        var pow = (int)Math.Pow(prime, window);

        var hash = 0;
        foreach (var ch in s.Take(window))
        {
            hash = hash * prime + hashMap[ch];
        }

        var map = new HashSet<int> { hash };
        var result = new HashSet<string>();
        for (var i = window; i < s.Length; i++)
        {
            hash *= prime;
            hash -= hashMap[s[i - window]] * pow;
            hash += hashMap[s[i]];

            if (map.Contains(hash))
            {
                result.Add(s[(i - 9)..(i + 1)]);
            }
            else
            {
                map.Add(hash);
            }
        }

        return result.ToArray();
    }
}