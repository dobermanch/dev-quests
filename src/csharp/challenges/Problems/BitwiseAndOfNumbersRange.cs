
// https://leetcode.com/problems/bitwise-and-of-numbers-range

namespace LeetCode.Problems;

public sealed class BitwiseAndOfNumbersRange : ProblemBase
{
    [Theory]
    [ClassData(typeof(BitwiseAndOfNumbersRange))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(1).Param(1).Result(1))
        .Add(it => it.Param(416).Param(436).Result(416))
        .Add(it => it.Param(5).Param(7).Result(4))
        .Add(it => it.Param(0).Param(0).Result(0))
        .Add(it => it.Param(1).Param(2147483647).Result(0))
        ;

    private int Solution(int left, int right)
    {
        while (right > left) 
        {
            right &= (right - 1);
        }

        return left & right;
    }
}
