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
        if (root == null)
        {
            return 0;
        }

        var count = 1;
        var level = 1;
        var node = root;
        while (node != null)
        {
            count += (int)Math.Pow(2, level++);
            if (node.right == null)
            {
                count += (int)Math.Pow(2, level) + (node.right != null  ? -1 : 0);
                break;
            }

            node = node.right;
        }

        return count;
    }
}