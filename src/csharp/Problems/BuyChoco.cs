//https://leetcode.com/problems/buy-two-chocolates

namespace LeetCode.Problems;

public sealed class BuyChoco : ProblemBase
{
    [Theory]
    [ClassData(typeof(BuyChoco))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[74,31,38,24,25,24,5]").Param(79).Result(50))
          .Add(it => it.ParamArray("[1,2,2]").Param(3).Result(0))
          .Add(it => it.ParamArray("[3,2,3]").Param(3).Result(3));

    private int Solution1(int[] prices, int money)
    {
        var result = int.MaxValue;
        var cost = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            result = Math.Max(result, cost - prices[i]);
            cost = Math.Max(cost, money - prices[i]);
        }

        return result < 0 ? money : result;
    }

    private int Solution2(int[] prices, int money)
    {
        Array.Sort(prices);

        var cost = prices[0] + prices[1];
        return cost > money ? money : money - cost;
    }
}