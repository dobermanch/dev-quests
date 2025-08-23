// https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array

namespace LeetCode.Problems;

public sealed class MaxProduct2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProduct2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[3,4,5,2]").Result(12))
          .Add(it => it.ParamArray("[1,5,4,5]").Result(16))
          .Add(it => it.ParamArray("[3,7]").Result(12));

    private int Solution(int[] nums)
    {
        var num1 = 0;
        var num2 = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > num1) 
            {
                num2 = num1;
                num1 = nums[i];
            }
            else if (nums[i] > num2)
            {
                num2 = nums[i];
            }
        }

        return (num1 - 1) * (num2 - 1);
    }
}