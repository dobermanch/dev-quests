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

    bool Compare(TreeNode? left1, TreeNode? right1)
    {
        if (left1 == null && right1 == null)
        {
            return true;
        }

        if (left1 == null || right1 == null)
        {
            return false;
        }

        return left1.val == right1.val
               && Compare(left1.left, right1.right)
               && Compare(left1.right, right1.left);
    }
}