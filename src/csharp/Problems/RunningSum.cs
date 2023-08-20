//https://leetcode.com/problems/running-sum-of-1d-array/

namespace LeetCode.Problems;

public sealed class RunningSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(RunningSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,4]").ResultArray("[1,3,6,10]"))
          .Add(it => it.ParamArray("[1,1,1,1,1]").ResultArray("[1,2,3,4,5]"))
          .Add(it => it.ParamArray("[3,1,2,10,1]").ResultArray("[3,4,6,16,17]"))
        ;

    private int[] Solution(int[] nums)
    {
        var result = new int[nums.Length];

        result[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] + nums[i];
        }

        return result;
    }
}