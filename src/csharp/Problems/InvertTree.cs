//https://leetcode.com/problems/invert-binary-tree/
namespace LeetCode.Problems;

public sealed class InvertTree : ProblemBase
{
    [Theory]
    [ClassData(typeof(InvertTree))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param<TreeNode>(4, 2, 7, 1, 3, 6, 9).Result<TreeNode>(4, 7, 2, 9, 6, 3, 1))
          .Add(it => it.Param<TreeNode>(2, 1, 3).Result<TreeNode>(2, 3, 1))
          .Add(it => it.Param<TreeNode>(null).Result<TreeNode>(null));

    private TreeNode? Solution(TreeNode? root)
    {
        if (root == null)
        {
            return null;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }

            (node.left, node.right) = (node.right, node.left);
        }

        return root;
    }
}