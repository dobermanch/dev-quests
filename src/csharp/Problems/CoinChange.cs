//https://leetcode.com/problems/coin-change/

namespace LeetCode.Problems;

public sealed class CoinChange : ProblemBase
{
    [Theory]
    [ClassData(typeof(CoinChange))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1))
            .Add(it => it.ParamArray("[10,6,5]").Param(27).Result(4))
            //.Add(it => it.ParamArray("[411,412,413,414,415,416,417,418,419,420,421,422]").Param(9864).Result(24))
            .Add(it => it.ParamArray("[186,419,83,408]").Param(6249).Result(20))
            .Add(it => it.ParamArray("[1,2,5]").Param(11).Result(3))
            .Add(it => it.ParamArray("[10,6,5]").Param(11).Result(2))
            .Add(it => it.ParamArray("[1,2147483647]").Param(2).Result(2))
            .Add(it => it.ParamArray("[2]").Param(1).Result(-1))
            .Add(it => it.ParamArray("[1]").Param(0).Result(0))
            .Add(it => it.ParamArray("[1]").Param(1).Result(1))
            .Add(it => it.ParamArray("[5]").Param(15).Result(3))
            .Add(it => it.ParamArray("[10,6]").Param(22).Result(3))
            .Add(it => it.ParamArray("[2]").Param(3).Result(-1));

    private int Solution(int[] coins, int amount)
    {
        int Find(int[] coins, int amount, int[] result)
        {
            if (amount < 0)
            {
                return -1;
            }

            if (amount == 0)
            {
                return 0;
            }

            if (result[amount - 1] != 0)
            {
                return result[amount - 1];
            }

            var min = int.MaxValue;
            foreach (var coin in coins)
            {
                var res = Find(coins, amount - coin, result);
                if (res >= 0 && res < min)
                {
                    min = 1 + res;
                }
            }

            return result[amount - 1] = min == int.MaxValue ? -1 : min;
        }

        return Find(coins, amount, new int[amount]);
    }

    private int Solution1(int[] coins, int amount)
    {
        var count = -1;

        var stack = new Stack<(int index, int count, int left, int prevCount)>();
        stack.Push((0, amount / coins[0] + 1, amount - coins[0] * (amount / coins[0] + 1), 0));

        while (stack.Any())
        {
            var coin = stack.Pop();

            coin.count--;
            coin.left += coins[coin.index];

            if (coin.count >= 1 && coin.index != coins.Length - 1)
            {
                stack.Push(coin);
            }

            for (var j = coin.index + 1; j < coins.Length; j++)
            {
                if (coin.left >= coins[j])
                {
                    coin = (j, coin.left / coins[j], coin.left, coin.count + coin.prevCount);
                    coin.left -= coin.count * coins[j];
                    stack.Push(coin);
                }
            }

            if (coin.left == 0)
            {
                count = count <= 0 ? coin.count + coin.prevCount : Math.Min(count, coin.count + coin.prevCount);
            }
        }

        return count;
    }
}