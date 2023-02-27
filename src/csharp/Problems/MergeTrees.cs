//https://leetcode.com/problems/merge-two-binary-trees/

namespace LeetCode.Problems;

public sealed class MergeTrees : ProblemBase
{
    [Theory]
    [ClassData(typeof(MergeTrees))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,3,2,5]").ParamTree("[2,1,3,null,4,null,7]").ResultTree("[3,4,5,5,4,null,7]"))
          .Add(it => it.ParamTree("[1,3,2,5]").ParamTree("[]").ResultTree("[1,3,2,5]"))
          .Add(it => it.ParamTree("[]").ParamTree("[]").ResultTree("[]"))
          .Add(it => it.ParamTree("[1]").ParamTree("[1,2]").ResultTree("[2,2]"));

    private TreeNode? Solution(TreeNode? root1, TreeNode? root2)
    {
        if (root1 == null && root2 == null)
        {
            return null;
        }

        var root = new TreeNode();

        var queue = new Queue<(TreeNode result, TreeNode? left, TreeNode? right)>();
        queue.Enqueue((root, root1, root2));

        while (queue.Any())
        {
            var current = queue.Dequeue();

            current.result.val = (current.left?.val ?? 0) + (current.right?.val ?? 0);

            if (current.left?.left != null || current.right?.left != null)
            {
                queue.Enqueue((current.result.left = new TreeNode(), current.left?.left, current.right?.left));
            }

            if (current.left?.right != null || current.right?.right != null)
            {
                queue.Enqueue((current.result.right = new TreeNode(), current.left?.right, current.right?.right));
            }
        }

        return root;
    }
}