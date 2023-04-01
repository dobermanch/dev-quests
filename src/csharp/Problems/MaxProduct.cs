//https://leetcode.com/problems/maximum-product-subarray

namespace LeetCode.Problems;

public sealed class MaxProduct : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxProduct))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,-2,4]").Result(6))
          .Add(it => it.ParamArray("[2,-5,3,-2,-7,3]").Result(126))
          .Add(it => it.ParamArray("[2,-5,-2,-4,3]").Result(24))
          .Add(it => it.ParamArray("[2,-4,2,4]").Result(8))
          .Add(it => it.ParamArray("[2,3,-2,4,-1]").Result(48))
          .Add(it => it.ParamArray("[-2,0,-1]").Result(0))
          .Add(it => it.ParamArray("[1,2,3,-4,2,4,-5,-2]").Result(960))
          .Add(it => it.ParamArray("[2,-3,2,-4]").Result(48))
          .Add(it => it.ParamArray("[-2,-3,-2,-4]").Result(48))
          .Add(it => it.ParamArray("[-2,0]").Result(0))
          .Add(it => it.ParamArray("[0,2]").Result(2))
          .Add(it => it.ParamArray("[2,0]").Result(2));

    private int Solution(int[] nums)
    {
        var result = nums[0];
        var max = 1;
        var min = 1;
        foreach (var num in nums)
        {
            var temp = num * max;
            max = Math.Max(num, Math.Max(num * max, num * min));
            min = Math.Min(num, Math.Min(temp, num * min));

            result = Math.Max(result, max);
        }

        return result;
    }
}