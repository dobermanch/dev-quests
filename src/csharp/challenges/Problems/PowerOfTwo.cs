//https://leetcode.com/problems/power-of-two/?envType=study-plan&id=algorithm-i

namespace LeetCode.Problems;

public sealed class IsPowerOfTwo : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsPowerOfTwo))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(1).Result(true))
          .Add(it => it.Param(0).Result(false))
          .Add(it => it.Param(-2147483648).Result(false))
          .Add(it => it.Param(16).Result(true))
          .Add(it => it.Param(32).Result(true))
          .Add(it => it.Param(9).Result(false))
          .Add(it => it.Param(9).Result(false));

    private bool Solution(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
}