// https://leetcode.com/problems/reverse-integer/

namespace LeetCode.Problems;

public sealed class Reverse : ProblemBase
{
    [Theory]
    [ClassData(typeof(Reverse))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(123).Result(321))
          .Add(it => it.Param(-123).Result(-321))
          .Add(it => it.Param(120).Result(21))
          .Add(it => it.Param(1534236469).Result(0)) 
          .Add(it => it.Param(-1534236469).Result(0));

    private int Solution(int x)
    {
        long result = 0;
        while (x != 0) 
        {
            result = result * 10 + x % 10;
            x /= 10;
        }

        if (result > int.MaxValue || result < int.MinValue)
        {
            return 0;
        }

        return (int)result;
    }
}