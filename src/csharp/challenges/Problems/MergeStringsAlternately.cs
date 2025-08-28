//https://leetcode.com/problems/merge-strings-alternately

namespace LeetCode.Problems;

public sealed class MergeAlternately : ProblemBase
{
    [Theory]
    [ClassData(typeof(MergeAlternately))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("abc").Param("pqr").Result("apbqcr"))
          .Add(it => it.Param("ab").Param("pqrs").Result("apbqrs"))
          .Add(it => it.Param("abcd").Param("pq").Result("apbqcd"));

    private string Solution(string word1, string word2)
    {
        var builder = new StringBuilder();

        var length = word1.Length > word2.Length ? word1.Length : word2.Length;

        for(var i = 0; i < length; i++)
        {
            if (i < word1.Length)
            {
                builder.Append(word1[i]);
            }

            if (i < word2.Length)
            {
                builder.Append(word2[i]);
            }
        }

        return builder.ToString();
    }
}