//https://leetcode.com/problems/two-sum/

namespace LeetCode.Problems;

public sealed class TwoSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(TwoSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,7,11,15]").Param(9).ResultArray("[0,1]"))
          .Add(it => it.ParamArray("[3,2,4]").Param(6).ResultArray("[1,2]"))
          .Add(it => it.ParamArray("[3,3]").Param(6).ResultArray("[0,1]"));

    private int[] Solution(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(target - nums[i], out var index))
            {
                return new[] { index, i };
            }

            map.TryAdd(nums[i], i);
        }

        return Array.Empty<int>();
    }

    private int[] Solution1(int[] nums, int target)
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