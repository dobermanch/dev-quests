//https://leetcode.com/problems/maximum-subarray/

namespace LeetCode.Problems;

public sealed class MaxSubArray : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxSubArray))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[-2,1,-3,4,-1,2,1,-5,4]").Result(6))
          .Add(it => it.ParamArray("[1]").Result(1))
          .Add(it => it.ParamArray("[-1]").Result(-1))
          .Add(it => it.ParamArray("[5,4,-1,7,8]").Result(23));

    private int Solution(int[] nums)
    {
        var sum = nums[0];
        var max = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            sum = Math.Max(sum + nums[i], nums[i]);
            max = Math.Max(max, sum);
        }

        return max;
    }
}