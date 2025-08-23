//https://leetcode.com/problems/maximum-product-difference-between-two-pairs

namespace LeetCode.Problems;

public sealed class MaxProductDifference : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProductDifference))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,6,7,5,2,4,10,6,4]").Result(68))
          .Add(it => it.ParamArray("[5,6,2,7,4]").Result(34))
          .Add(it => it.ParamArray("[4,2,5,9,7,4,8]").Result(64));

    private int Solution(int[] nums)
    {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;
        var max1 = int.MinValue;
        var max2 = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max1)
            {
                max2 = max1;
                max1 = nums[i];
            }
            else if (nums[i] > max2)
            {
                max2 = nums[i];
            }

            if (nums[i] < min1)
            {
                min2 = min1;
                min1 = nums[i];
            }
            else if (nums[i] < min2)
            {
                min2 = nums[i];
            }
        }

        return (max1 * max2) - (min1 * min2);
    }

    private int Solution2(int[] nums)
    {
        Array.Sort(nums);

        return (nums[^2] * nums[^1]) - (nums[0] * nums[1]);
    }
}