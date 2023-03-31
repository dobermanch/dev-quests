//https://leetcode.com/problems/product-of-array-except-self/

namespace LeetCode.Problems;

public sealed class ProductExceptSelf : ProblemBase
{
    [Theory]
    [ClassData(typeof(ProductExceptSelf))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[0,2,3,4]").ResultArray("[24,0,0,0]"))
          .Add(it => it.ParamArray("[1,2,3,4]").ResultArray("[24,12,8,6]"))
          .Add(it => it.ParamArray("[-1,1,0,-3,3]").ResultArray("[0,0,9,0,0]"))
          .Add(it => it.ParamArray("[1,2,3,4,5]").ResultArray("[120,60,40,30,24]"))
          .Add(it => it.ParamArray("[-1,1,0,-3,0,3]").ResultArray("[0,0,0,0,0,0]"));

    private int[] Solution(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            result[i + 1] = result[i] * nums[i];
        }

        var product = nums[^1];
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            result[i] *= product;
            product *= nums[i];
        }

        return result;
    }
}