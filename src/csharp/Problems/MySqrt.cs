//https://leetcode.com/problems/sqrtx

namespace LeetCode.Problems;

public sealed class MySqrt : ProblemBase
{
    [Theory]
    [ClassData(typeof(MySqrt))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(122).Result(11))
          .Add(it => it.Param(2147395600).Result(46340))
          .Add(it => it.Param(2).Result(1))
          .Add(it => it.Param(1).Result(1))
          .Add(it => it.Param(0).Result(0))
          .Add(it => it.Param(4).Result(2))
          .Add(it => it.Param(8).Result(2))
          ;

    private int Solution1(int x)
    {
        long left = 0;
        long right = x;
        while (left <= right)
        {
            var root = (left + right) / 2;
            var target = root * root;

            if (target == x)
            {
                return (int)root;
            }
            else if (target < x)
            {
                left = root + 1;
            }
            else
            {
                right = root - 1;
            }
        }

        return (int)right;
    }

    public int Solution2(int x)
    {
        var root = 0L;
        while (root * root <= x)
        {
            root++;
        }

        return (int)root - 1;
    }
}