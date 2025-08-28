// https://leetcode.com/problems/range-sum-of-bst/

namespace LeetCode.Problems;

public sealed class RangeSumBST : ProblemBase
{
    [Theory]
    [ClassData(typeof(RangeSumBST))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[10,5,15,3,7,null,18]").Param(7).Param(15).Result(32))
          .Add(it => it.ParamTree("[10,5,15,3,7,13,18,1,null,6]").Param(6).Param(10).Result(23));

    private int Solution(TreeNode root, int low, int high)
    {
        int Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            return
                (node.val >= low && node.val <= high ? node.val : 0)
                + Dfs(node.left)
                + Dfs(node.right);
        }

        return Dfs(root);
    }
}