//https://leetcode.com/problems/domino-and-tromino-tiling

namespace LeetCode.Problems;

public sealed class NumTilings : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumTilings))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(1000).Result(979232805))
          .Add(it => it.Param(7).Result(117))
          .Add(it => it.Param(6).Result(53))
          .Add(it => it.Param(5).Result(24))
          .Add(it => it.Param(4).Result(11))
          .Add(it => it.Param(3).Result(5))
          .Add(it => it.Param(2).Result(2))
          .Add(it => it.Param(1).Result(1));

    private int Solution(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        var mod = (int)Math.Pow(10, 9) + 7;
        var treeBack = 0;
        var twoBack = 1;
        var oneBack = 1;
        var result = 0;
        while (--n > 0)
        {
            result = (int)((oneBack * 2.0 + treeBack) % mod);
            treeBack = twoBack;
            twoBack = oneBack;
            oneBack = result;
        }

        return result;
    }
}