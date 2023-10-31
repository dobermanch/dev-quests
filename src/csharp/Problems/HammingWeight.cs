//https://leetcode.com/problems/number-of-1-bits/

namespace LeetCode.Problems;

public sealed class HammingWeight : ProblemBase
{
    [Theory]
    [ClassData(typeof(HammingWeight))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param<uint>(11).Result(3))
          .Add(it => it.Param<uint>(128).Result(1))
          .Add(it => it.Param<uint>(4294967293).Result(31));

    private int Solution(uint n)
    {
        var count = 0;

        while (n > 0)
        {
            n &= n - 1;
            count++;
        }

        return count;
    }

    private int Solution1(uint n)
    {
        var count = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                count++;
            }

            n >>= 1;
        }

        return count;
    }
    
    private int Solution2(uint n)
    {
        var count = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                count++;
            }

            n /= 2;
        }

        return count;
    }
}