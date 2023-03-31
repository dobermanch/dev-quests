//https://leetcode.com/problems/rotate-array

namespace LeetCode.Problems;

public sealed class Rotate : ProblemBase
{
    [Theory]
    [ClassData(typeof(Rotate))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,4,5,6]").Param(4).ResultArray("[3,4,5,6,1,2]"))
          .Add(it => it.ParamArray("[1,2,3,4,5,6]").Param(3).ResultArray("[4,5,6,1,2,3]"))
          .Add(it => it.ParamArray("[1,2,3,4,5,6,7]").Param(3).ResultArray("[5,6,7,1,2,3,4]"))
          .Add(it => it.ParamArray("[1,2,3,4,5,6,7]").Param(8).ResultArray("[7,1,2,3,4,5,6]"))
          .Add(it => it.ParamArray("[-1,-100,3,99]").Param(2).ResultArray("[3,99,-1,-100]"))
          .Add(it => it.ParamArray("[1,2]").Param(3).ResultArray("[2,1]"))
          .Add(it => it.ParamArray("[-1]").Param(2).ResultArray("[-1]"));

    private int[] Solution(int[] nums, int k)
    {
        var index = 0;
        var prev = nums[index];
        var visited = 0;
        var count = 0;
        while (count++ < nums.Length)
        {
            index += k;
            if (index >= nums.Length)
            {
                index %= nums.Length;
            }

            (nums[index], prev) = (prev, nums[index]);

            if (index == visited && index < nums.Length - 1)
            {
                visited++;
                prev = nums[++index];
            }
        }

        return nums;
    }
}