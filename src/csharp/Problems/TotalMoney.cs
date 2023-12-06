//https://leetcode.com/problems/calculate-money-in-leetcode-bank

namespace LeetCode.Problems;

public sealed class TotalMoney : ProblemBase
{
    [Theory]
    [ClassData(typeof(TotalMoney))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Result(10))
          .Add(it => it.Param(10).Result(37))
          .Add(it => it.Param(20).Result(96));

    private int Solution(int n) 
    {
        var week = 0;
        var result = 0;
        for (var i = 0; i < n; i++)
        {
            var day = i % 7;
            if (day == 0)
            {
                week++;
            }

            result += week + day;
        }

        return result;
    }
}