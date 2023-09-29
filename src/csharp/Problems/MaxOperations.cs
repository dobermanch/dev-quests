//https://leetcode.com/problems/max-number-of-k-sum-pairs

namespace LeetCode.Problems;

public sealed class MaxOperations : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxOperations))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,4]").Param(5).Result(2))
          .Add(it => it.ParamArray("[3,1,3,4,3]").Param(6).Result(1))
          .Add(it => it.ParamArray("[4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4]").Param(2).Result(2));

    private int Solution(int[] nums, int k)
    {
        Array.Sort(nums);

        var result = 0;
        var left = 0;
        var right = nums.Length - 1;
        while (left < right) 
        {
            var sum = nums[left] + nums[right];
            if (sum == k) 
            {
                left++;
                right--;
                result++;
            }
            else if (sum > k) 
            {
                right--;
            }
            else 
            {
                left++;
            }
        }

        return result;
    }
}