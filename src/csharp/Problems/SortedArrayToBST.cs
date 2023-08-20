//https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/

namespace LeetCode.Problems;

public sealed class SortedArrayToBst : ProblemBase
{
    [Theory]
    [ClassData(typeof(SortedArrayToBst))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray(-10,-3,0,5,9).ResultTree("[0,-3,9,-10,null,5]"))
          .Add(it => it.ParamArray(1,3).ResultTree("[3,1]"))
          .Add(it => it.ParamArray(-10,-3,0,5,9).ResultTree("[0,-3,9,-10,null,5]"))
          .Add(it => it.ParamArray(0,1,2,3,4,5).ResultTree("[3,1,5,0,2,4]"))
        ;

    private TreeNode Solution(int[] nums)
    {
        TreeNode? BuildTree(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            var length = end - start;
            int mid = start + length / 2;

            mid += length % 2 == 0 ? 0 : 1;

            return new TreeNode(nums[mid])
            {
                left = BuildTree(nums, start, mid - 1),
                right = BuildTree(nums, mid + 1, end)
            };
        }

        return BuildTree(nums, 0, nums.Length - 1);
    }
}