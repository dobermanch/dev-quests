//https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii

namespace LeetCode.Problems;

public sealed class FindMinimumInRotatedSortedArrayIi : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMinimumInRotatedSortedArrayIi))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray([10,1,10,10,10]).Result(1))
          .Add(it => it.ParamArray([3,3,3,5,1,3,3]).Result(1))
          .Add(it => it.ParamArray([3,3,1,3]).Result(1))
          .Add(it => it.ParamArray([1,3,3]).Result(1))
          .Add(it => it.ParamArray([1,3,5]).Result(1))
          .Add(it => it.ParamArray([2,2,2,0,1]).Result(0))
          .Add(it => it.ParamArray([1,1,1,1,1,1,1,1,1,1,1,1,1]).Result(1))
          ;

    private int Solution1(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else if (nums[left] == nums[mid] && nums[mid] == nums[right])
            {
                right--;
            }
            else
            {
                right = mid;
            }
        }


        return nums[left];
    }
}