//https://leetcode.com/problems/subarray-sums-divisible-by-k/

namespace LeetCode.Problems;

public sealed class SubarraysDivByK : ProblemBase
{
    [Theory]
    [ClassData(typeof(SubarraysDivByK))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[4,5,0,-2,-3,1]").Param(5).Result(7))
          .Add(it => it.ParamArray("[5]").Param(9).Result(0))
        ;

    private int Solution(int[] nums, int k)
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