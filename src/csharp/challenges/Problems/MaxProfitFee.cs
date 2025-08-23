//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee

namespace LeetCode.Problems;

public sealed class MaxProfitFee : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProfitFee))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,3,2,8,4,9]").Param(2).Result(8))
          .Add(it => it.ParamArray("[1,3,7,5,10,3]").Param(3).Result(6));

    private int Solution(int[] prices, int fee)
    {
        var temp = -prices[0];
        var profit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            temp = Math.Max(temp, profit - prices[i]);
            profit = Math.Max(profit, temp + prices[i] - fee);
        }

        return profit;
    }
}