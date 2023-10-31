//https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

namespace LeetCode.Problems;

public sealed class MaxProfit : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProfit))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[7,1,5,3,6,4]").Result(5))
            .Add(it => it.ParamArray("[7,6,4,3,1]").Result(0));

    private int Solution(int[] prices)
    {
        var buyDay = 0;
        var profit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[buyDay] > prices[i])
            {
                buyDay = i;
            }
            else
            {
                var temp = prices[i] - prices[buyDay];
                if (temp > profit)
                {
                    profit = temp;
                }
            }
        }

        return profit;
    }
}