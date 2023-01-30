//https://leetcode.com/problems/find-pivot-index/

namespace LeetCode.Problems;

public sealed class PivotIndex : ProblemBase
{
    public static void Run()
    {
        var nums = new[] { 1, 7, 3, 6, 5, 6 };
        //var nums = new []{1,2,3};
        //var nums = new []{2,1,-1};
        //var nums = new []{-1,-1,-1,0,1,1};
        //var nums = new []{-1,-1,-1,-1,-1,0};
        var d = Run(nums);
    }

    private static int Run(int[] nums)
    {
        var leftSum = 0;
        var rightSum = 0;
        var index = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        while (leftSum != rightSum && index < nums.Length - 1)
        {
            leftSum += nums[index];
            rightSum -= nums[index + 1];
            index++;
        }

        return leftSum != rightSum ? -1 : index;
    }
}