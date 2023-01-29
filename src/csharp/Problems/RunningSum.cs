//https://leetcode.com/problems/running-sum-of-1d-array/

namespace LeetCode.Problems;

public sealed class RunningSum : ProblemBase
{
    public static void Run()
    {
        var result = Run(new [] {1,2,3,4}); // [1,3,6,10]
        //var result = Run(new [] {1,1,1,1,1}); // [1,2,3,4,5]
        //var result = Run(new [] {3,1,2,10,1}); // [3,4,6,16,17]
    }

    private static int[] Run(int[] nums) 
    {
        var result = new int[nums.Length];

        result[0] = nums[0];
        for(var i = 1; i < nums.Length; i++) {
            result[i] = result[i - 1] + nums[i];
        }

        return result;
    }
}