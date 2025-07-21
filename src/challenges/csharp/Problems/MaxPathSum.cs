//https://leetcode.com/problems/binary-tree-maximum-path-sum/

namespace LeetCode.Problems;

public sealed class MaxPathSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxPathSum))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[9,6,-3,null,null,-6,2,null,null,2,null,-6,-6,-6]").Result(16))
          .Add(it => it.ParamTree("[-1,-2,10,-6,null,-3,-6]").Result(10))
          .Add(it => it.ParamTree("[1,2,3,4,5,5,3,7,1,3,8]").Result(26))
          .Add(it => it.ParamTree("[1,-2,3]").Result(4))
          .Add(it => it.ParamTree("[1,2,3]").Result(6))
          .Add(it => it.ParamTree("[1]").Result(1))
          .Add(it => it.ParamTree("[-3]").Result(-3))
          .Add(it => it.ParamTree("[-10,9,20,null,null,15,7]").Result(42))
          .Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,null,1]").Result(48))
          .Add(it => it.ParamTree("[1,2,null,3,null,4,null,5]").Result(15));

    private int Solution(TreeNode root)
    {
        var max = root.val;
        int Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            var left = Dfs(node.left);
            var right= Dfs(node.right);

            var nodeMax = Math.Max(node.val + left, node.val + right);
            nodeMax = Math.Max(node.val, nodeMax);

            max = Math.Max(max, nodeMax);
            max = Math.Max(max, left + right + node.val);

            return nodeMax;
        }

        Dfs(root);

        return max;
    }
}