//https://leetcode.com/problems/kth-smallest-element-in-a-bst/

namespace LeetCode.Problems;

public sealed class KthSmallest : ProblemBase
{
    [Theory]
    [ClassData(typeof(KthSmallest))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param<TreeNode>(5, 3, 6, 2, 4, null, null, 1).Param(3).Result(3))
          .Add(it => it.Param<TreeNode>(3, 1, 4, null, 2).Param(1).Result(1))
          .Add(it => it.Param<TreeNode>(5, 3, 6, 2, 4, null, null, 1).Param(6).Result(6));

    private int Solution(TreeNode root, int k)
    {
        TreeNode? result = null;
        Search(root, 0, k, ref result);

        return result?.val ?? 0;
    }

    private int Search(TreeNode? node, int parent, int k, ref TreeNode? result)
    {
        if (node == null || result != null)
        {
            return 0;
        }

        var count = parent;
        count += Search(node.left, count, k, ref result);

        if (++count == k)
        {
            result = node;
        }
        else
        {
            count += Search(node.right, count, k, ref result);
        }

        return count - parent;
    }
}