//https://leetcode.com/problems/diameter-of-binary-tree/

namespace LeetCode.Problems;

public sealed class DiameterOfBinaryTree : ProblemBase
{
    [Theory]
    [ClassData(typeof(DiameterOfBinaryTree))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1, 2, 3, 4, 5]").Result(3))
          .Add(it => it.ParamTree("[4, -7, -3, null, null, -9, -3, 9, -7, -4, null, 6, null, -6, -6, null, null, 0, 6, 5, null, 9, null, null, -1, -4, null, null, null, -2]").Result(8))
          .Add(it => it.ParamTree("[1, 2]").Result(1));

    private int Solution(TreeNode root)
    {
        (int maxPath, int depth) Diameter(TreeNode? node)
        {
            if (node == null)
            {
                return (0, 0);
            }

            var left = Diameter(node.left);
            var right = Diameter(node.right);

            var depth = 1 + Math.Max(left.depth, right.depth);
            var maxPath = Math.Max(left.maxPath, right.maxPath);
            maxPath = Math.Max(maxPath, left.depth + right.depth);

            return (maxPath, depth);
        }

        return Diameter(root).maxPath;
    }
}