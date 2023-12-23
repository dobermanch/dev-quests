// https://leetcode.com/problems/count-complete-tree-nodes

namespace LeetCode.Problems;

public sealed class CountNodes : ProblemBase
{
    [Theory]
    [ClassData(typeof(CountNodes))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,3,4,5,6]").Result(6))
          .Add(it => it.ParamTree("[]").Result(0))
          .Add(it => it.ParamTree("[1]").Result(1));

    private int Solution(TreeNode root)
    {
        int Count(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }

            var node = root;
            var leftDepth = 0;
            while (node != null)
            {
                node = node.left;
                leftDepth++;
            }

            node = root;
            var rightDepth = 0;
            while (node != null)
            {
                node = node.right;
                rightDepth++;
            }

            if (leftDepth == rightDepth)
            {
                return (int)Math.Pow(2, leftDepth) - 1;
            }

            return 1 + Count(root.left) + Count(root.right);
        }

        return Count(root);
    }
}