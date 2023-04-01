//https://leetcode.com/problems/partition-equal-subset-sum/

namespace LeetCode.Problems;

public sealed class CanPartition : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanPartition))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,5,11,5]").Result(true))
          .Add(it => it.ParamArray("[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,97,95]").Result(true))
          .Add(it => it.ParamArray("[23,13,11,7,6,5,5]").Result(true))
          .Add(it => it.ParamArray("[1,5,3,4,5,6,11,5]").Result(true))
          .Add(it => it.ParamArray("[3,5,11,5]").Result(false))
          .Add(it => it.ParamArray("[1,2,3,5]").Result(false))
          .Add(it => it.ParamArray("[1,2,3,4]").Result(true))
        ;

    private bool Solution(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false;
        }

        sum /= 2;

        var map = new bool[sum + 1];
        map[0] = true;

        foreach (var num in nums)
        {
            for (int i = sum; i >= num; i--)
            {
                map[i] = map[i] || map[i - num];
            }

            if (map[sum])
            {
                return true;
            }
        }

        return map[sum];
    }
}