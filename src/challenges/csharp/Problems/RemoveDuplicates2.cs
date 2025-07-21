// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii

namespace LeetCode.Problems;

public sealed class RemoveDuplicates2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveDuplicates2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,1,1,2,2,3]").Result(5))
          .Add(it => it.ParamArray("[0,0,1,1,1,1,2,3,3]").Result(7));

    private int Solution(int[] nums) 
    {
        var left = 1;
        var count = 1;
        for (var right = 1; right < nums.Length; right++)
        {
            count = nums[right] == nums[right - 1] ? count + 1 : 1;
            
            if (count <= 2)
            {
                nums[left++] = nums[right];
            }
        }

        return left;
    }
}