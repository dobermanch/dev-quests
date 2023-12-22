//https://leetcode.com/problems/maximum-score-after-splitting-a-string

namespace LeetCode.Problems;

public sealed class MaxScoreSplit : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxScoreSplit))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("00").Result(5))
          .Add(it => it.Param("011101").Result(5))
          .Add(it => it.Param("00111").Result(5))
          .Add(it => it.Param("1111").Result(3));

    private int Solution(string s)
    {
        var ones = new int[s.Length + 1];

        for (int i = s.Length - 1; i >= 0; i--)
        {
            ones[i] = ones[i + 1] + (s[i] == '1' ? 1 : 0);
        }

        var zeroCount = 0;
        var score = 0;
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '0')
            {
                zeroCount++;
            }

            score = Math.Max(score, zeroCount + ones[i + 1]);
        }

        return score;
    }
}