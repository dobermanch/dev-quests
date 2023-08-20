//https://leetcode.com/problems/validate-binary-search-tree/

namespace LeetCode.Problems;

public sealed class IsValidBST : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsValidBST))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[2,1,3]").Result(true))
          .Add(it => it.ParamTree("[5,1,4,null,null,3,6]").Result(false))
        ;

    private bool Solution(TreeNode root)
    {
        var stack = new Stack<(int? left, int? right, TreeNode node)>();
        stack.Push((null, null, root));
        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.node.right != null)
            {
                if (current.node.right.val <= current.node.val || current.left != null && current.node.right.val >= current.left)
                {
                    return false;
                }

                stack.Push((current.left, Math.Min(current.node.val, current.left ?? current.node.val), current.node.right));
            }

            if (current.node.left != null)
            {
                if (current.node.left.val >= current.node.val || current.right != null && current.node.left.val <= current.right)
                {
                    return false;
                }

                stack.Push((Math.Max(current.node.val, current.right ?? current.node.val), current.right, current.node.left));
            }
        }

        return true;
    }
}