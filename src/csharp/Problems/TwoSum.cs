//https://leetcode.com/problems/two-sum/

namespace LeetCode.Problems;

public sealed class TwoSum : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new [] {2,7,11,15}, 9);
        //var d = Run(new [] {3,2,4}, 6);
        var d = Run(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
    }

    //Option 2
    private static int[] Run(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(target - nums[i], out var index))
            {
                return new[] { index, i };
            }
            else
            {
                map.TryAdd(nums[i], i);
            }
        }

        return Array.Empty<int>();
    }

    //Option 1
    private static int[] Run1(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        return Array.Empty<int>();
    }
}