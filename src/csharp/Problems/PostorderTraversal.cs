//https://leetcode.com/problems/binary-tree-postorder-traversal/

namespace LeetCode.Problems;

public sealed class PostorderTraversal : ProblemBase
{
    [Theory]
    [ClassData(typeof(PostorderTraversal))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1,null,2,3]").ResultArray("[3,2,1]"))
          .Add(it => it.ParamTree("[1,5,2,3,4,5,6,7,8,9,10]").ResultArray("[7,8,3,9,10,4,5,5,6,2,1]"))
          .Add(it => it.ParamTree("[1,null,2,3,4,5,6,7,8,9,10]").ResultArray("[9,10,5,6,3,7,8,4,2,1]"))
          .Add(it => it.ParamTree("[1,5,2,3,4,5,6,7,8,9,10,null,null,null,null,null,null,11,12]").ResultArray("[7,11,12,8,3,9,10,4,5,5,6,2,1]"))
          .Add(it => it.ParamTree("[1]").ResultArray("[1]"))
          .Add(it => it.ParamTree("[]").ResultArray("[]"));

    private IList<int>? Solution(TreeNode? root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any())
        {
            var node = stack.Pop();
            result.Insert(0, node.val);

            if (node.left != null)
            {
                stack.Push(node.left);
            }

            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }

        return result;
    }

    private IList<int>? Solution1(TreeNode? root)
    {
        void Dfs(TreeNode? node, List<int> result)
        {
            if (node == null) return;

            Dfs(node.left, result);
            Dfs(node.right, result);

            result.Add(node.val);
        }

        var result = new List<int>();
        Dfs(root, result);

        return result;
    }
}