// https://leetcode.com/problems/remove-element

namespace LeetCode.Problems;

public sealed class RemoveElement : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveElement))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[0,1,2,2,3,0,4,2]").Param(2).Result(5))
          .Add(it => it.ParamArray("[3,2,2,3]").Param(3).Result(2));

    private int Solution(int[] nums, int val) 
    {
        var left = 0;
        for (var right = 0; right < nums.Length; right++)
        {
            if (nums[right] != val)
            {
                nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }
}