//https://leetcode.com/problems/fibonacci-number/description

namespace LeetCode.Problems;

public sealed class Fibonacci : ProblemBase
{
    [Theory]
    [ClassData(typeof(Fibonacci))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1))
            .Add(it => it.Param(2).Result(1))
            .Add(it => it.Param(3).Result(2))
            .Add(it => it.Param(4).Result(3))
            .Add(it => it.Param(15).Result(610));

    private int Solution(int n)
    {
        if (n is 1 or 0)
        {
            return n;
        }

        var t0 = 0;
        var t1 = 1;
        while (--n > 0)
        {
            var temp = t1;
            t1 = t1 + t0;
            t0 = temp;
        }

        return t1;
    }

    private int Solution1(int n)
    {
        int Fib(int n)
        {
            if (n is 1 or 0)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        return Fib(n);
    }
}