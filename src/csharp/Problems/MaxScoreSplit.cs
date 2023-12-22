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
        var oneCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                oneCount++;
            }
        }

        var zeroCount = 0;
        var score = 0;
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '0')
            {
                zeroCount++;
            }
            else
            {
                oneCount--;
            }

            score = Math.Max(score, zeroCount + oneCount);
        }

        return score;
    }
}