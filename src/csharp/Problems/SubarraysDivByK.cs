//https://leetcode.com/problems/subarray-sums-divisible-by-k/

namespace LeetCode.Problems;

public sealed class SubarraysDivByK : ProblemBase
{
    public static void Run()
    {
        var d = Run(new int[] { 4, 5, 0, -2, -3, 1 }, 5);
        //var d = Run(new int[]{5}, 9);
    }

    private static int Run(int[] nums, int k)
    {
        var map = new int[k];
        map[0] = 1;

        int count = 0;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            int mod = sum % k;
            if (mod < 0)
            {
                mod += k;
            }

            count += ++map[mod] - 1;
        }

        return count;
    }
}