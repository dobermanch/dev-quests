//https://leetcode.com/problems/longest-increasing-subsequence/

namespace LeetCode.Problems;

public sealed class LengthOfLIS : ProblemBase
{
    [Theory]
    [ClassData(typeof(LengthOfLIS))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[10,9,2,5,3,7,101,18]").Result(4))
          .Add(it => it.ParamArray("[0,1,0,3,2,3]").Result(4))
          .Add(it => it.ParamArray("[0,1,0,4,2,3]").Result(4))
          .Add(it => it.ParamArray("[4,10,4,3,8,9]").Result(3))
          .Add(it => it.ParamArray("[7,7,7,7,7,7,7]").Result(1));

    private int Solution(int[] nums)
    {
        var map = new List<int> { nums[0] };
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > map[^1])
            {
                map.Add(nums[i]);
                continue;
            }

            for (int j = 0; j < map.Count; j++)
            {
                if (map[j] >= nums[i])
                {
                    map[j] = nums[i];
                    break;
                }
            }
        }

        return map.Count;
    }

    private int Solution1(int[] nums)
    {
        var map = new int[nums.Length];
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                {
                    map[i] = Math.Max(map[i], map[j]);
                }
            }

            map[i] += 1;
        }

        return map.Max();
    }
}