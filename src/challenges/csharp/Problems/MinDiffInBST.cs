// https://leetcode.com/problems/minimum-distance-between-bst-nodes/

namespace LeetCode.Problems;

public sealed class MinDiffInBST : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinDiffInBST))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[4,2,6,1,3]").Result(1))
          .Add(it => it.ParamTree("[1,0,48,null,null,12,49]").Result(1))
          .Add(it => it.ParamTree("[10,0,48,null,null,16,56]").Result(6));

    private int Solution(TreeNode? root)
    {
        var stack = new Stack<TreeNode>();
        TreeNode? prevNode = null;
        var diff = int.MaxValue;

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
                if (prevNode != null)
                {
                    diff = Math.Min(diff, pop.val - prevNode.val);
                }

                prevNode = pop;

                node = pop.right;
            }
        }

        return diff;
    }
}