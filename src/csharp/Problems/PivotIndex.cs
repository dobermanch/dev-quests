//https://leetcode.com/problems/find-pivot-index/

namespace LeetCode.Problems;

public sealed class PivotIndex : ProblemBase
{
    [Theory]
    [ClassData(typeof(PivotIndex))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,7,3,6,5,6]").Result(3))
          .Add(it => it.ParamArray("[1,2,3]").Result(-1))
          .Add(it => it.ParamArray("[2,1,-1]").Result(0))
        ;

    private int Solution(int[] nums)
    {
        var leftSum = 0;
        var rightSum = 0;
        var index = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        while (leftSum != rightSum && index < nums.Length - 1)
        {
            leftSum += nums[index];
            rightSum -= nums[index + 1];
            index++;
        }

        return leftSum != rightSum ? -1 : index;
    }
}