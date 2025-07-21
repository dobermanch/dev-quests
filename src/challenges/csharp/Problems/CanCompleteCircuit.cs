//https://leetcode.com/problems/gas-station

namespace LeetCode.Problems;

public sealed class CanCompleteCircuit : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanCompleteCircuit))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,4,5]").ParamArray("[3,4,5,1,2]").Result(3))
          .Add(it => it.ParamArray("[2,3,4]").ParamArray("[3,4,3]").Result(-1))
          .Add(it => it.ParamArray("[2]").ParamArray("[2]").Result(0))
          .Add(it => it.ParamArray("[2,0,0,0]").ParamArray("[0,1,0,0]").Result(0))
          .Add(it => it.ParamArray("[3,1,1]").ParamArray("[1,2,2]").Result(0))
          .Add(it => it.ParamArray("[5,1,2,3,4]").ParamArray("[4,4,1,5,1]").Result(4));

    private int Solution(int[] gas, int[] cost)
    {
        var startAt = 0;
        var sum = 0;
        var total = 0;
        for (var i = 0; i < gas.Length; i++)
        {
            total += gas[i] - cost[i];
            sum += gas[i] - cost[i];

            if (sum < 0)
            {
                sum = 0;
                startAt = i + 1;
            }
        }

        return total >= 0 ? startAt : -1;
    }

    private int Solution2(int[] gas, int[] cost)
    {
        var starCosts = new PriorityQueue<int, int>();
        for (var i = 0; i < gas.Length; i++)
        {
            var starCost = gas[i] - cost[i];
            if (starCost >= 0)
            {
                starCosts.Enqueue(i, -starCost);
            }
        }

        while (starCosts.Count > 0)
        {
            var startAt = starCosts.Dequeue();
            var tank = 0;
            var index = startAt;
            do
            {
                tank += gas[index];
                var prev = index;
                if (++index >= gas.Length)
                {
                    index = 0;
                }

                tank = tank - cost[prev];
            } while (tank > 0 && index != startAt);


            if (tank >= 0 && index == startAt)
            {
                return startAt;
            }
        }

        return -1;
    }
}