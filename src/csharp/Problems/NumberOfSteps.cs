//https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/

namespace LeetCode.Problems;

public sealed class NumberOfSteps : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumberOfSteps))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(14).Result(6))
          .Add(it => it.Param(8).Result(4))
          .Add(it => it.Param(123).Result(12))
        ;

    private int Solution(int num)
    {
        var result = 0;
        while (num != 0)
        {
            if (num % 2 == 0)
            {
                num >>= 1;
            }
            else
            {
                num -= 1;
            }

            result++;
        }

        return result;
    }
}