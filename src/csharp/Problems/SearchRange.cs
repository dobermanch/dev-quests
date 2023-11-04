//https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

namespace LeetCode.Problems;

public sealed class SearchRange : ProblemBase
{
    [Theory]
    [ClassData(typeof(SearchRange))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,2]").Param(2).ResultArray("[1,2]"))
          .Add(it => it.ParamArray("[8,8,8,8,8,10]").Param(8).ResultArray("[0,4]"))
          .Add(it => it.ParamArray("[1]").Param(0).ResultArray("[-1,-1]"))
          .Add(it => it.ParamArray("[1,3]").Param(1).ResultArray("[0,0]"))
          .Add(it => it.ParamArray("[5,7,7,8,8,10]").Param(8).ResultArray("[3,4]"))
          .Add(it => it.ParamArray("[5,7,7,8,8,10]").Param(6).ResultArray("[-1,-1]"))
          .Add(it => it.ParamArray("[]").Param(0).ResultArray("[-1,-1]"));

    private int[] Solution1(int[] nums, int target)
    {
        int Search(int[] nums, int target, bool searchLeft)
        {
            var left = 0;
            var right = nums.Length - 1;
            var index = -1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    index = mid;
                    if (searchLeft)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }

            return index;
        }

        return new[]
        {
            Search(nums, target, true),
            Search(nums, target, false)
        };
    }

    private int[] Solution2(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[left] == target && nums[right] == target)
            {
                return new[] { left, right };
            }

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = nums[left] == target ? left : left + 1;
                right = nums[right] == target ? right : right - 1;
            }
        }

        return new[] { -1, -1 };
    }
}