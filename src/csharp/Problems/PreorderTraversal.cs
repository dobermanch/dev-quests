//https://leetcode.com/problems/binary-tree-preorder-traversal/

namespace LeetCode.Problems;

public sealed class PreorderTraversal : ProblemBase
{
    [Theory]
    [ClassData(typeof(PreorderTraversal))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,null,2,3]").ResultArray("[1,2,3]"))
          .Add(it => it.ParamTree("[1,null,2,3,4,5,6,7,8,9,10]").ResultArray("[1,2,3,5,9,10,6,4,7,8]"))
          .Add(it => it.ParamTree("[1]").ResultArray("[1]"))
          .Add(it => it.ParamTree("[]").ResultArray("[]"));

    private IList<int>? Solution(TreeNode? root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();

        var node = root;
        while (node != null || stack.Any())
        {
            if (node != null)
            {
                result.Add(node.val);
                stack.Push(node);
                node = node.left;
            }
            else
            {
                var pop = stack.Pop();
                node = pop.right;
            }
        }

        return result;
    }
}