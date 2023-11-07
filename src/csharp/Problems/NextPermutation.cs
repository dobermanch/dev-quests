//https://leetcode.com/problems/next-permutation

namespace LeetCode.Problems;

public sealed class NextPermutation : ProblemBase
{
    [Theory]
    [ClassData(typeof(NextPermutation))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,1]").ResultArray("[1,1]"))
          .Add(it => it.ParamArray("[5,1,1]").ResultArray("[1,1,5]"))
          .Add(it => it.ParamArray("[4,2,0,2,3,2,0]").ResultArray("[4,2,0,3,0,2,2]"))
          .Add(it => it.ParamArray("[1,4,3,2]").ResultArray("[2,1,3,4]"))
          .Add(it => it.ParamArray("[2,2,0,4,3,1]").ResultArray("[2,2,1,0,3,4]"))
          .Add(it => it.ParamArray("[8,11,3]").ResultArray("[11,3,8]"))
          .Add(it => it.ParamArray("[50,10,40,30,20]").ResultArray("[50,20,10,30,40]"))
          .Add(it => it.ParamArray("[2,3,1]").ResultArray("[3,1,2]"))
          .Add(it => it.ParamArray("[1,2,3]").ResultArray("[1,3,2]"))
          .Add(it => it.ParamArray("[3,2,1]").ResultArray("[1,2,3]"))
          .Add(it => it.ParamArray("[1,1,5]").ResultArray("[1,5,1]"));

    private int[] Solution1(int[] nums)
    {
        var right = nums.Length - 1;
        var left = right - 1;
        var found = false;
        while (left >= 0)
        {
            if (!found && nums[left] < nums[right])
            {
                found = true;
                right = nums.Length;
            }
            else if (!found)
            {
                left--;
                right--;
            }
            else if (found && nums[left] < nums[--right])
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                break;
            }
        }

        Array.Reverse(nums, left + 1, nums.Length - (left + 1));

        return nums;
    }

    //private int[] Solution2(int[] nums)
    //{
    //    var right = nums.Length - 2;
    //    while (right >= 0 && nums[right] >= nums[right + 1])
    //    {
    //        right--;
    //    }

    //    var left = right;
    //    if (right >= 0)
    //    {
    //        right = nums.Length - 1;
    //        while (left < right && nums[left] >= nums[right])
    //        {
    //            right--;
    //        }

    //        (nums[left], nums[right]) = (nums[right], nums[left]);
    //    }

    //    Array.Reverse(nums, left + 1, nums.Length - (left + 1));

    //    return nums;
    //}
}