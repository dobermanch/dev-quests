//https://leetcode.com/problems/move-zeroes/

namespace LeetCode.Problems;

public sealed class MoveZeroes : ProblemBase
{
    [Theory]
    [ClassData(typeof(MoveZeroes))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[0,1,0,3,12]").ResultArray("[1,3,12,0,0]"))
          .Add(it => it.ParamArray("[1]").ResultArray("[1]"))
          .Add(it => it.ParamArray("[0,1,0]").ResultArray("[1,0,0]"))
          .Add(it => it.ParamArray("[0,1,0,0]").ResultArray("[1,0,0,0]"))
          .Add(it => it.ParamArray("[0]").ResultArray("[0]"));

    private int[] Solution(int[] nums)
    {
        var index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }

            nums[index] = nums[i];

            if (index != i)
            {
                nums[i] = 0;
            }

            index++;
        }

        return nums;
    }
}