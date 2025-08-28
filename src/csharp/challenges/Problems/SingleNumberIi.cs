//https://leetcode.com/problems/single-number-ii

namespace LeetCode.Problems;

public sealed class SingleNumber2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(SingleNumber2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[-2,-2,1,1,4,1,4,4,-4,-2]").Result(-4))
          .Add(it => it.ParamArray("[5,8,88,5,8,5,8]").Result(88))
          .Add(it => it.ParamArray("[2,2,3,2]").Result(3));

    private int Solution1(int[] nums)
    {
        var mask1 = 0;
        var mask2 = 0;
        foreach (var num in nums)
        {
            mask1 ^= num & ~mask2;
            mask2 ^= num & ~mask1;
        }

        return mask1;
    }

    private int Solution2(int[] nums)
    {
        var result = 0;
        for (var i = 0; i <= 31; i++)
        {
            var count = 0;
            var mask = 1 << i;
            foreach (var num in nums)
            {
                if ((num & mask) != 0)
                {
                    count++;
                }
            }

            if (count % 3 != 0)
            {
                result |= mask;
            }
        }

        return result;
    }

    private int Solution3(int[] nums)
    {
        var bits = new int[32];
        foreach (var num in nums)
        {
            for (var i = 0; i <= 31; i++)
            {
                if ((num & (1 << i)) != 0)
                {
                    bits[i]++;
                }
            }
        }

        var result = 0;
        for (var i = 0; i <= 31; i++)
        {
            if (bits[i] % 3 != 0)
            {
                result |= (1 << i);
            }
        }

        return result;
    }
}