
// https://leetcode.com/problems/factorial-trailing-zeroes

namespace LeetCode.Problems;

public sealed class FactorialTrailingZeroes : ProblemBase
{
    [Theory]
    [ClassData(typeof(FactorialTrailingZeroes))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(23).Result(4))
          .Add(it => it.Param(4).Result(0))
          .Add(it => it.Param(3).Result(0))
          .Add(it => it.Param(5).Result(1))
        ;

    private int Solution(int n)
    {
        if (n <= 4) 
        {
            return 0;
        }

        var count = 0;
        var power = 1;
        while (power < n)
        {
            power *= 5;
            count += n / power;
        }

        return count;
    }
}
