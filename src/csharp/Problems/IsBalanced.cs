//https://leetcode.com/problems/balanced-binary-tree/

namespace LeetCode.Problems;

public sealed class IsBalanced : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsBalanced))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3, 9, 20, null, null, 15, 7]").Result(true))
          .Add(it => it.ParamTree("[1, 2, 2, 3, 3, null, null, 4, 4]").Result(false))
          .Add(it => it.ParamTree("[1, 2, 2, 3, null, null, 3, 4, null, null, 4]").Result(false))
          .Add(it => it.ParamTree("[1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5]").Result(true))
          .Add(it => it.ParamTree("[]").Result(true));

    private bool Solution(TreeNode? root)
    {
        if (root == null)
        {
            return true;
        }

        (bool balanced, int depth) Depth(TreeNode? node)
        {
            if (node == null)
            {
                return (true, 0);
            }

            var left = Depth(node.left);
            var right = Depth(node.right);

            var balanced = left.balanced && right.balanced && Math.Abs(left.depth - right.depth) <= 1;
            var depth = 1 + Math.Max(left.depth, right.depth);

            return (balanced, depth);
        }

        return Depth(root).balanced;
    }
}