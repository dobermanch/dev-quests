// https://leetcode.com/problems/sum-root-to-leaf-numbers

namespace LeetCode.Problems;

public sealed class SumNumbers : ProblemBase
{
    [Theory]
    [ClassData(typeof(SumNumbers))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[9]").Result(9))
          .Add(it => it.ParamTree("[1,5,2,3,4,5,6,7,8,9]").Result(4875))
          .Add(it => it.ParamTree("[4,9,0,5,1]").Result(1026))
          .Add(it => it.ParamTree("[1,2,3]").Result(25));

    private int Solution(TreeNode? root)
    {
        int Sum(TreeNode? node, int accum)
        {
            if (node is null)
            {
                return 0;
            }

            accum += node.val;

            if (node.left is null && node.right is null)
            {
                return accum;
            }

            accum *= 10;

            return Sum(node.left, accum) + Sum(node.right, accum);
        }

        return Sum(root, 0);
    }

    private int Solution1(TreeNode? root)
    {
        var stack = new Stack<TreeNode>();
        var sum = 0;

        var node = root;
        while (node != null || stack.Any())
        {
            var prevNode = node;
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    sum += node.val;
                }

                stack.Push(node);
                node = node.left;
            }
            else
            {
                prevNode = stack.Pop();
                node = prevNode.right;
            }

            if (node != null && prevNode != null)
            {
                node.val += prevNode.val * 10;
            }
        }

        return sum;
    }
}