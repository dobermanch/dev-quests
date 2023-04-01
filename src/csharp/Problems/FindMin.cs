//https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

namespace LeetCode.Problems;

public sealed class FindMin : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMin))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[3,4,5,1,2]").Result(1))
          .Add(it => it.ParamArray("[2,1]").Result(1))
          .Add(it => it.ParamArray("[1,2]").Result(1))
          .Add(it => it.ParamArray("[1]").Result(1))
          .Add(it => it.ParamArray("[4,5,6,7,8,9,0,1,2,3]").Result(0))
          .Add(it => it.ParamArray("[4,5,6,7,0,1,2]").Result(0))
          .Add(it => it.ParamArray("[5,6,7,0,1,2,4]").Result(0))
          .Add(it => it.ParamArray("[2,4,5,6,7,0,1]").Result(0))
          .Add(it => it.ParamArray("[6,7,0,1,2,4,5]").Result(0))
          .Add(it => it.ParamArray("[11,13,15,17]").Result(11));

    private int Solution(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[right] < nums[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left];
    }
}