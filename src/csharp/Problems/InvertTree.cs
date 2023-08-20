//https://leetcode.com/problems/invert-binary-tree/
namespace LeetCode.Problems;

public sealed class InvertTree : ProblemBase
{
    [Theory]
    [ClassData(typeof(InvertTree))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[4, 2, 7, 1, 3, 6, 9]").ResultTree("[4, 7, 2, 9, 6, 3, 1]"))
          .Add(it => it.ParamTree("[2, 1, 3]").ResultTree("[2, 3, 1]"))
          .Add(it => it.ParamTree("[]").ResultTree("[]"));

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