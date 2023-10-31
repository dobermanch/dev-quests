//https://leetcode.com/problems/maximum-depth-of-binary-tree/

namespace LeetCode.Problems;

public sealed class MaxDepth : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxDepth))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,9,20,null,null,15,7]").Result(3))
          .Add(it => it.ParamTree("[3,9,20,null,null,15,7,12,34,4,34,34]").Result(5))
          .Add(it => it.ParamTree("[1,null,2]").Result(2))
          .Add(it => it.ParamTree("[]").Result(0));

    private int Solution(TreeNode root)
    {
        int Dfs(TreeNode? node, int depth)
        {
            if (node == null)
            {
                return depth;
            }

            var left = Dfs(node.left, depth);
            var right = Dfs(node.right, depth);

            return 1 + Math.Max(left, right);
        }

        return Dfs(root, 0);
    }
}