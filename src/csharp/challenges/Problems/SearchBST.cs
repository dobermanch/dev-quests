//https://leetcode.com/problems/search-in-a-binary-search-tree/

namespace LeetCode.Problems;

public sealed class SearchBST : ProblemBase
{
    [Theory]
    [ClassData(typeof(SearchBST))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[4,2,7,1,3]").Param(2).ResultTree("[2,1,3]"))
          .Add(it => it.ParamTree("[4,2,7,1,3]").Param(5).ResultTree("[]"));

    private TreeNode? Solution(TreeNode root, int val)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Any())
        {
            var node = stack.Pop();

            if (node.val == val)
            {
                return node;
            }

            if (val < node.val && node.left is not null)
            {
                stack.Push(node.left);
            }
            else if (node.right is not null)
            {
                stack.Push(node.right);
            }
        }

        return null;
    }
}