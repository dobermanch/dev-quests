//https://leetcode.com/problems/number-of-dice-rolls-with-target-sum

namespace LeetCode.Problems;

public sealed class NumRollsToTarget : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumRollsToTarget))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(1).Param(6).Param(3).Result(1))
          .Add(it => it.Param(2).Param(6).Param(7).Result(6))
          .Add(it => it.Param(30).Param(30).Param(500).Result(222616187));

    private int Solution(int n, int k, int target)
    {
        int mod = 1000000007;
        int[][] dp = new int[n + 1][];
        dp[0] = new int[target + 1];
        dp[0][0] = 1;

        for (int i = 1; i <= n; i++)
        {
            dp[i] = new int[target + 1];
            for (int j = 1; j <= k; j++)
            {
                for (int t = j; t <= target; t++)
                {
                    dp[i][t] = (dp[i][t] + dp[i - 1][t - j]) % mod;
                }
            }
        }

        return dp[n][target];
    }
}