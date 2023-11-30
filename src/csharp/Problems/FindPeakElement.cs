//https://leetcode.com/problems/find-peak-element

namespace LeetCode.Problems;

public sealed class FindPeakElement : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindPeakElement))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,4,3,5,6,4]").Result(5))
          .Add(it => it.ParamArray("[3,2,1,3,5,6,4]").Result(5))
          .Add(it => it.ParamArray("[1,2,1,3,5,6,4]").Result(5))
          .Add(it => it.ParamArray("[1,2,3,1]").Result(2));

    private int Solution1(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (mid < nums.Length - 1 && nums[mid] < nums[mid + 1])
            {
                left = mid + 1;
            }
            else if (mid > 0 && nums[mid - 1] > nums[mid])
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return 0;
    }
}