//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/

namespace LeetCode.Problems;

public sealed class LowestCommonAncestor : ProblemBase
{
    [Theory]
    [ClassData(typeof(LowestCommonAncestor))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,5,1,6,2,0,8,null,null,7,4]").ParamTree("[5]").ParamTree("[1]").ResultTree("[3,5,1,6,2,0,8,null,null,7,4]"))
          .Add(it => it.ParamTree("[3,5,1,6,2,0,8,null,null,7,4]").ParamTree("[5]").ParamTree("[4]").ResultTree("[5,6,2,null,null,7,4]"))
          .Add(it => it.ParamTree("[3,5,1,6,2,0,8,null,null,7,4]").ParamTree("[6]").ParamTree("[7]").ResultTree("[5,6,2,null,null,7,4]"))
          .Add(it => it.ParamTree("[1,11,2,3,4,5,6,7,8,9,10]").ParamTree("[7]").ParamTree("[9]").ResultTree("[11,3,4,7,8,9,10]"))
        ;

    private TreeNode? Solution(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode? Dfs(TreeNode? node, TreeNode node1, TreeNode node2)
        {
            if (node == null || node.val == node1.val || node.val == node2.val)
            {
                return node;
            }

            var left = Dfs(node.left, node1, node2);
            var right = Dfs(node.right, node1, node2);

            return left != null && right != null ? node : left ?? right;
        }

        return Dfs(root, p, q);
    }
}