//https://leetcode.com/problems/search-in-rotated-sorted-array/
namespace LeetCode.Problems;

public sealed class Search : ProblemBase
{
    [Theory]
    [ClassData(typeof(Search))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray(5, 1, 2, 3, 4).Param(1).Result(1))
          .Add(it => it.ParamArray(4, 5, 6, 7, 8, 1, 2, 3).Param(8).Result(4))
          .Add(it => it.ParamArray(5, 1, 3).Param(5).Result(0))
          .Add(it => it.ParamArray(3, 1).Param(1).Result(1))
          .Add(it => it.ParamArray(4, 5, 6, 7, 0, 1, 2).Param(0).Result(4))
          .Add(it => it.ParamArray(3, 4, 5, 6, 7, 0, 1, 2).Param(0).Result(5))
          .Add(it => it.ParamArray(4, 5, 6, 7, 0, 1, 2, 3).Param(0).Result(4))
          .Add(it => it.ParamArray(0, 1, 2, 3, 4, 5, 6, 7).Param(2).Result(2))
          .Add(it => it.ParamArray(1, 2, 3, 4, 5, 6, 7, 0).Param(4).Result(3))
          .Add(it => it.ParamArray(4, 5, 6, 7, 0, 1, 2).Param(3).Result(-1))
          .Add(it => it.ParamArray(1).Param(0).Result(-1))
          ;

    private int Solution(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] > target && (nums[start] > nums[mid] || nums[start] <= target)
                || (nums[end] < target && (nums[end] > nums[mid] || nums[end] >= target)))
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return -1;
    }

    private int Solution1(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;

        if (nums[0] > nums[^1])
        {
            while (start != end)
            {
                var mid = start + (end - start) / 2;
                if (nums[mid] >= nums[0])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
        }

        var k = nums.Length - start;
        start = 0;
        end = nums.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            var index = mid - k;
            if (index < 0)
            {
                index = nums.Length + index;
            }

            if (nums[index] == target)
            {
                return index;
            }

            if (nums[index] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return -1;
    }
}