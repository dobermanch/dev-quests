//https://leetcode.com/problems/binary-search/

namespace LeetCode.Problems;

public sealed class BinarySearch : ProblemBase
{
    [Theory]
    [ClassData(typeof(BinarySearch))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[-1, 0, 3, 5, 9, 12]").Param(2).Result(-1))
            .Add(it => it.ParamArray("[-1,0,3,5,9,12]").Param(9).Result(4));

    private int Solution(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;
        do
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        while (end >= start);

        return -1;
    }
}