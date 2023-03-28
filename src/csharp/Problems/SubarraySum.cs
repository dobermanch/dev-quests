//https://leetcode.com/problems/subarray-sum-equals-k/

namespace LeetCode.Problems;

public sealed class SubarraySum : ProblemBase
{
    [Theory]
    [ClassData(typeof(SubarraySum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,1,1]").Param(2).Result(2))
          .Add(it => it.ParamArray("[1,1,1,1,1]").Param(3).Result(3))
          .Add(it => it.ParamArray("[1,2,3]").Param(3).Result(2))
          .Add(it => it.ParamArray("[1,2,3,4,5,6]").Param(2).Result(1))
          .Add(it => it.ParamArray("[1,2,3]").Param(7).Result(0))
          .Add(it => it.ParamArray("[1]").Param(0).Result(0))
          .Add(it => it.ParamArray("[1,-1,0]").Param(0).Result(3))
          .Add(it => it.ParamArray("[2,3,6,5,4,1,10]").Param(5).Result(3))
          .Add(it => it.ParamArray("[2,2,4,4,6,8,5,8]").Param(4).Result(3))
        ;

    private int Solution(int[] nums, int k)
    {
        var map = new Dictionary<int, int>
        {
            {0, 1}
        };

        var sum = 0;
        var result = 0;
        foreach (var num in nums)
        {
            sum += num;

            if (map.ContainsKey(sum - k))
            {
                result += map[sum - k];
            }

            if (!map.ContainsKey(sum))
            {
                map[sum] = 0;
            }

            map[sum]++;
        }

        return result;
    }
}