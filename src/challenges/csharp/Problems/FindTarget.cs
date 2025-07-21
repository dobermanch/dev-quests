//https://leetcode.com/problems/two-sum-iv-input-is-a-bst/

namespace LeetCode.Problems;

public sealed class FindTarget : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindTarget))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[5,3,6,2,4,null,7]").Param(9).Result(true))
          .Add(it => it.ParamTree("[5,3,6,2,4,null,7]").Param(28).Result(false));

    private bool Solution(TreeNode root, int k)
    {
        var map = new HashSet<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Any())
        {
            var node = stack.Pop();

            if (map.Contains(k - node.val))
            {
                return true;
            }

            map.Add(node.val);

            if (node.left != null)
            {
                stack.Push(node.left);
            }

            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }

        return false;
    }
}