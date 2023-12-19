// https://leetcode.com/problems/minimum-size-subarray-sum

namespace LeetCode.Problems;

public sealed class MinSubArrayLen : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinSubArrayLen))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(7).ParamArray("[2,3,1,2,4,3]").Result(2))
          .Add(it => it.Param(7).ParamArray("[2,3,3,2,4,1]").Result(3))
          .Add(it => it.Param(2).ParamArray("[2]").Result(1))
          .Add(it => it.Param(7).ParamArray("[2]").Result(0))
          .Add(it => it.Param(4).ParamArray("[1,4,4]").Result(1))
          .Add(it => it.Param(11).ParamArray("[1,1,1,1,1,1,1,1]").Result(0));

    private int Solution(int target, int[] nums)
    {
        var result = int.MaxValue;
        var left = 0;
        var right = 0;
        var sum = 0;
        while (right < nums.Length || sum >= target)
        {
            if (sum >= target)
            {
                result = Math.Min(result, right - left);
                sum -= nums[left];
                left++;
            }
            else if (right < nums.Length)
            {
                sum += nums[right];
                right++;
            }
        }

        return result == int.MaxValue ? 0 : result;
    }
}