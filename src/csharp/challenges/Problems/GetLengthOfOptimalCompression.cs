//https://leetcode.com/problems/string-compression-ii

namespace LeetCode.Problems;

public sealed class GetLengthOfOptimalCompression : ProblemBase
{
    [Theory]
    [ClassData(typeof(GetLengthOfOptimalCompression))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("aaabcccd").Param(2).Result(4))
          .Add(it => it.Param("aabbaa").Param(2).Result(2))
          .Add(it => it.Param("aaaaaaaaaaa").Param(0).Result(3));

    private int Solution(string s, int k)
    {
        var map = new int[k + 1, s.Length + 1];
        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 0; j <= i && j <= k; j++)
            {
                map[j, i] = j > 0 ? map[j - 1, i - 1] : int.MaxValue;

                var remove = 0;
                var count = 0;
                for (var k1 = i; k1 >= 1; k1--)
                {
                    if (s[i - 1] != s[k1 - 1])
                    {
                        remove += 1;
                    }
                    else
                    {
                        count += 1;
                    }

                    if (remove > j)
                    {
                        break;
                    }

                    var length = count switch
                    {
                        1 => 1,
                        < 10 => 2,
                        < 100 => 3,
                        _ => 4
                    };

                    map[j, i] = Math.Min(map[j, i], map[j - remove, k1 - 1] + length);
                }
            }
        }

        return map[k, s.Length];
    }
}