//https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/

namespace LeetCode.Problems;

public sealed class LongestSubarray : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestSubarray))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,1,0,1]").Result(3))
          .Add(it => it.ParamArray("[0,1,1,1,0,1,1,0,1]").Result(5))
          .Add(it => it.ParamArray("[1,1,1]").Result(2))
        ;

    private int Solution(int[] nums)
    {
        var count = 0;
        var left = 0;
        for(var right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                count++;
            }

            if (count > 1)
            {
                if(nums[left] == 0)
                {
                    count--;
                }

                left++;
            }
        }

        return nums.Length - left - 1;
    }
}