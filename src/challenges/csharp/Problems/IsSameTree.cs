//https://leetcode.com/problems/same-tree/

namespace LeetCode.Problems;

public sealed class IsSameTree : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsSameTree))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[1,2,3]").ParamTree("[1,2,3]").Result(true))
          .Add(it => it.ParamTree("[1,2]").ParamTree("[1,null,2]").Result(false))
          .Add(it => it.ParamTree("[1,2,1]").ParamTree("[1,1,2]").Result(false));

    private bool Solution(TreeNode p, TreeNode q)
    {
        bool Dfs(TreeNode? left, TreeNode? right)
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
                   && Dfs(left.left, right.left) 
                   && Dfs(left.right, right.right);
        }

        return Dfs(p, q);
    }
}