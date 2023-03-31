//https://leetcode.com/problems/search-insert-position/

namespace LeetCode.Problems;

public sealed class SearchInsert : ProblemBase
{
    [Theory]
    [ClassData(typeof(SearchInsert))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,3]").Param(2).Result(1))
          .Add(it => it.ParamArray("[1,3,5,6]").Param(5).Result(2))
          .Add(it => it.ParamArray("[1,3,5,6]").Param(2).Result(1))
          .Add(it => it.ParamArray("[1,3,5,6]").Param(7).Result(4))
          .Add(it => it.ParamArray("[1,3,5,6]").Param(0).Result(0));

    private int Solution(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;

        var index = 0;
        while (start <= end)
        {
            index = start + (end - start) / 2;
            if (nums[index] == target)
            {
                break;
            }

            if (nums[index] > target)
            {
                end = index - 1;
            }
            else
            {
                index = start = index + 1;
            }
        }

        return index;
    }
}