//https://leetcode.com/problems/contains-duplicate-ii

namespace LeetCode.Problems;

public sealed class ContainsNearbyDuplicate : ProblemBase
{
    [Theory]
    [ClassData(typeof(ContainsNearbyDuplicate))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,1]").Param(3).Result(true))
          .Add(it => it.ParamArray("[1,0,1,1]").Param(1).Result(true))
          .Add(it => it.ParamArray("[1,2,3,1,2,3]").Param(2).Result(false));

    private bool Solution(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]) && i - map[nums[i]] <= k)
            {
                return true;
            }

            map[nums[i]] = i;
        }

        return false;
    }
}