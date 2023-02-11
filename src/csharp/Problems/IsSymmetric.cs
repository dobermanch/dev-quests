//https://leetcode.com/problems/symmetric-tree/

namespace LeetCode.Problems;

public sealed class IsSymmetric : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsSymmetric))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,2,3,4,4,3]").Result(true))
          .Add(it => it.ParamTree("[1,2,2,null,3,null,3]").Result(false))
          .Add(it => it.ParamTree("[1,2,2,5,null,null,5,6,null,null,6]").Result(true));

    private bool Solution(TreeNode root)
    {
        return Compare(root.left, root.right);
    }

    bool Compare(TreeNode? left, TreeNode? right)
    {
        if (left == null && right == null)
        {
            return true;
        }

        if (left == null || right == null)
        {
            return false;
        }

        return left.val == right.val
               && Compare(left.left, right.right)
               && Compare(left.right, right.left);
    }
}