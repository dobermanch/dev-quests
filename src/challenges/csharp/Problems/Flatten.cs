//https://leetcode.com/problems/flatten-binary-tree-to-linked-list/

namespace LeetCode.Problems;

public sealed class Flatten : ProblemBase
{
    [Theory]
    [ClassData(typeof(Flatten))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,5,3,4,null,6]").ResultTree("[1,null,2,null,3,null,4,null,5,null,6]"))
          .Add(it => it.ParamTree("[]").ResultTree("[]"))
          .Add(it => it.ParamTree("[0]").ResultTree("[0]"));

    private TreeNode Solution1(TreeNode root)
    {
        var node = root;
        while (node != null)
        {
            if (node.left != null)
            {
                var currnet = node.left;
                while (currnet.right != null)
                {
                    currnet = currnet.right;
                }

                currnet.right = node.right;
                node.right = node.left;
                node.left = null;
            }

            node = node.right;
        }

        return root;
    }

    private TreeNode Solution2(TreeNode root)
    {
        var stack = new Stack<TreeNode>();

        var node = root;
        TreeNode? prev = null;
        while (node != null || stack.Any())
        {
            if (node != null)
            {
                stack.Push(node);
                prev = node;
                node = node.left;
            }
            else
            {
                var pop = stack.Pop();
                node = pop.right;

                if (prev != null)
                {
                    prev.right = node;
                    if (pop.left != null)
                    {
                        pop.right = pop.left;
                        pop.left = null;
                    }
                }
            }
        }

        return root;
    }
}