//https://leetcode.com/problems/climbing-stairs/description

namespace LeetCode.Problems;

public sealed class ClimbStairs : ProblemBase
{
    [Theory]
    [ClassData(typeof(ClimbStairs))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(2).Result(2))
            .Add(it => it.Param(3).Result(3))
            .Add(it => it.Param(10).Result(89));

    private int Solution(int n)
    {
        if (n is 1 or 0)
        {
            return n;
        }

        var t0 = 0;
        var t1 = 1;
        while (n-- > 0)
        {
            var temp = t1;
            t1 += t0;
            t0 = temp;
        }

        return t1;
    }
}