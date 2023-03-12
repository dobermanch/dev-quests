//https://leetcode.com/problems/binary-tree-preorder-traversal/

namespace LeetCode.Problems;

public sealed class PreorderTraversal : ProblemBase
{
    [Theory]
    [ClassData(typeof(PreorderTraversal))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.ParamTree("[1,null,2,3]").ResultArray("[1,2,3]"))
          .Add(true, it => it.ParamTree("[1,null,2,3,4,5,6,7,8,9,10]").ResultArray("[1,2,3,5,9,10,6,4,7,8]"))
          .Add(true, it => it.ParamTree("[1]").ResultArray("[1]"))
          .Add(it => it.ParamTree("[]").ResultArray("[]"));

    private IList<int>? Solution(TreeNode? root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();
        var stack = new Stack<(TreeNode node, bool print)>();
        stack.Push((root, true));

        while (stack.Any())
        {
            var current = stack.Pop();
            if (current.print)
            {
                result.Add(current.node.val);
            }

            if (current.node.right != null)
            {
                stack.Push((current.node.right, true));
            }

            if (current.node.left != null)
            {
                result.Add(current.node.left.val);
                stack.Push((current.node.left, false));
            }
        }

        return result;
    }
}