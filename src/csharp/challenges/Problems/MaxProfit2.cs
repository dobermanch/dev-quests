//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii

namespace LeetCode.Problems;

public sealed class MaxProfit2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProfit2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[7,1,5,3,6,4]").Result(7))
          .Add(it => it.ParamArray("[1,2,3,4,5]").Result(4))
          .Add(it => it.ParamArray("[7,6,4,3,1]").Result(0));

    private int Solution(int[] prices)
    {
        var profit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                profit += prices[i] - prices[i - 1];
            }
        }

        return profit;
    }
}