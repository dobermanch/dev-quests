//https://leetcode.com/problems/binary-tree-inorder-traversal/

namespace LeetCode.Problems;

public sealed class InorderTraversal : ProblemBase
{
    [Theory]
    [ClassData(typeof(InorderTraversal))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1))
          .Add(it => it.ParamTree("[1,5,2,3,4,5,6,7,8,9,10]").ResultArray("[7,3,8,5,9,4,10,1,5,2,6]"))
          .Add(it => it.ParamTree("[1,null,2,3]").ResultArray("[1,3,2]"))
          .Add(it => it.ParamTree("[1,null,2,3,4,5,6,7,8,9,10]").ResultArray("[1,9,5,10,3,6,2,7,4,8]"))
          .Add(it => it.ParamTree("[1]").ResultArray("[1]"))
          .Add(it => it.ParamTree("[]").ResultArray("[]"));

    private IList<int> Solution(TreeNode? root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();

        var node = root;
        while (node != null || stack.Any())
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            else
            {
                var pop = stack.Pop();
                result.Add(pop.val);

                node = pop.right;
            }
        }

        return result;
    }

    private IList<int> Solution1(TreeNode? root)
    {
        void Dfs(TreeNode? node, IList<int> result)
        {
            if (node is null)
            {
                return;
            }
            
            Dfs(node.left, result);

            result.Add(node.val);

            Dfs(node.right, result);
        }

        var result = new List<int>();
        Dfs(root, result);

        return result;
    }
}