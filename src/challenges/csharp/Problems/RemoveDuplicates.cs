// https://leetcode.com/problems/remove-duplicates-from-sorted-array

namespace LeetCode.Problems;

public sealed class RemoveDuplicates : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveDuplicates))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[0,0,1,1,1,2,2,3,3,4]").Result(5))
          .Add(it => it.ParamArray("[1,1,2]").Result(2));

    private int Solution(int[] nums) 
    {
        var left = 1;
        for (var right = 1; right < nums.Length; right++)
        {
            if (nums[right] != nums[right - 1])
            {
                nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }
}