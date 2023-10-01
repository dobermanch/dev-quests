//https://leetcode.com/problems/max-consecutive-ones-iii/

namespace LeetCode.Problems;

public sealed class LongestOnes : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestOnes))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,1,1,0,0,0,1,1,1,1,0]").Param(2).Result(6))
          .Add(it => it.ParamArray("[0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1]").Param(3).Result(10));

    private int Solution(int[] nums, int k)
    {
        var result = 0;
        var left = 0;
        var right = 0;

        while (right < nums.Length)
        {
            if (nums[right] == 1)
            {
                right++;
            } 
            else if (k > 0)
            {
                k--;
                right++;
            } 
            else if (nums[left++] == 0) 
            {
                k++;
            }

            result = Math.Max(result, right - left);
        }	
        
        return result;
    }
}