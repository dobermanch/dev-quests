//https://leetcode.com/problems/sum-of-two-integers/

namespace LeetCode.Problems;

public sealed class GetSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(GetSum))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(-1).Param(1).Result(0))
          .Add(it => it.Param(17).Param(5).Result(22))
          .Add(it => it.Param(10).Param(12).Result(22))
          .Add(it => it.Param(15).Param(12).Result(27));

    private int Solution(int a, int b)
    {
        while (b != 0)
        {
            var carry = b & a;
            a ^= b;
            b = carry << 1;
        }
        return a;
    }
}