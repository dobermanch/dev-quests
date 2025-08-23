//https://leetcode.com/problems/min-cost-climbing-stairs/description

namespace LeetCode.Problems;

public sealed class MinCostClimbingStairs : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinCostClimbingStairs))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[10,15,20]").Result(15))
          .Add(it => it.ParamArray("[1,100,1,1,1,100,1,1,100,1]").Result(6))
        ;

    //Option 2
    private int Solution(int[] cost)
    {
        var paid1 = cost[0];
        var paid2 = Math.Min(cost[1] + paid1, cost[1]);

        for (var stair = 2; stair < cost.Length; stair++)
        {
            var temp = paid2;
            paid2 = Math.Min(cost[stair] + paid2, cost[stair] + paid1);
            paid1 = temp;
        }

        return Math.Min(paid1, paid2);
    }

    //Option 1
    private int Solution1(int[] cost)
    {
        var paid = new int[cost.Length];
        paid[0] = cost[0];
        paid[1] = Math.Min(cost[1] + paid[0], cost[1]);

        var index = 1;
        while (++index < cost.Length)
        {
            paid[index] = Math.Min(cost[index] + paid[index - 1], cost[index] + paid[index - 2]);
        }

        return paid[^2..].Min();
    }
}