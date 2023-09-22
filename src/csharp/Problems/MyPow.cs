//https://leetcode.com/problems/powx-n/

namespace LeetCode.Problems;

public sealed class MyPow : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyPow))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(2.0).Param(10).Result(1024.0))
          .Add(it => it.Param(2.1).Param(3).Result(9.26100))
          .Add(it => it.Param(2.0).Param(0).Result(1.0))
          .Add(it => it.Param(0.0).Param(21).Result(0.0))
          .Add(it => it.Param(2.0).Param(-2147483648).Result(0.0))
          .Add(it => it.Param(1.0).Param(-2147483648).Result(1.0))
          .Add(it => it.Param(-1.0).Param(-2147483648).Result(1.0))
          .Add(it => it.Param(-1.0).Param(2147483647).Result(-1.0))
          .Add(it => it.Param(1.0).Param(2147483647).Result(1.0))
          .Add(it => it.Param(1.0000000000001).Param(-2147483648).Result(0.99979))
          .Add(it => it.Param(-5.0).Param(-12).Result(0.0))
          .Add(it => it.Param(2.0).Param(-2).Result(0.25));

    private double Solution(double x, int n)
    {
        if (x == 0)
        {
            return 0.0;
        }

        var pow = n;
        var num = x;
        if (pow < 0)
        {
            pow = -pow;
            num = 1.0 / num;
        }

        double result = 1;
        while (pow != 0) 
        {
            if (pow % 2 != 0) // pow & 1 != 0
            {
                result *= num;
            } 

            num *= num;
            pow /= 2; // pow >>= 1;
        }

        return result;
    }
}