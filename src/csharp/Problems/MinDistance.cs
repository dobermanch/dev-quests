//https://leetcode.com/problems/edit-distance

namespace LeetCode.Problems;

public sealed class MinDistance : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinDistance))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("sitting").Param("kitten").Result(3))
          .Add(it => it.Param("horse").Param("ros").Result(3))
          .Add(it => it.Param("intention").Param("execution").Result(5))
          .Add(it => it.Param("").Param("a").Result(1))
          .Add(it => it.Param("").Param("").Result(0));

    private int Solution1(string word1, string word2)
    {
        var map = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i <= word1.Length; i++)
        {
            map[i, 0] = i;
        }

        for (int i = 0; i <= word2.Length; i++)
        {
            map[0, i] = i;
        }

        for (int i = 1; i <= word1.Length; i++)
        {
            for (var j = 1; j <= word2.Length; j++)
            {
                var add = word1[i - 1] == word2[j - 1] ? 0 : 1;
                var min = Math.Min(map[i - 1, j] + 1, map[i, j - 1] + 1);
                map[i, j] = Math.Min(min, map[i - 1, j - 1] + add);
            }
        }

        return map[word1.Length, word2.Length];
    }
}