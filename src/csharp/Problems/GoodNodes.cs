//https://leetcode.com/problems/count-good-nodes-in-binary-tree/

namespace LeetCode.Problems;

public sealed class GoodNodes : ProblemBase
{
    [Theory]
    [ClassData(typeof(GoodNodes))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[3,1,4,3,null,1,5]").Result(4))
          .Add(it => it.ParamTree("[3,3,null,4,2]").Result(3))
          .Add(it => it.ParamTree("[1]").Result(1));

    private int Solution(TreeNode root)
    {
        var stack = new Stack<(TreeNode, int)>();
        stack.Push((root, int.MinValue));
        var count = 0;
        while (stack.Any())
        {
            var (node, parentMax) = stack.Pop();

            count += node.val >= parentMax ? 1 : 0;

            parentMax = Math.Max(parentMax, node.val);

            if (node.left != null)
            {
                stack.Push((node.left, parentMax));
            }

            if (node.right != null)
            {
                stack.Push((node.right, parentMax));
            }
        }

        return count;
    }

    private int Solution1(TreeNode root)
    {
        int Dfs(TreeNode? node, int parentMax)
        {
            if (node == null)
            {
                return 0;
            }

            var count = node.val >= parentMax ? 1 : 0;

            parentMax = Math.Max(parentMax, node.val);

            count += Dfs(node.left, parentMax);
            count += Dfs(node.right, parentMax);

            return count;
        }

        return Dfs(root, int.MinValue);
    }
}