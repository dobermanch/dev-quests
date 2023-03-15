//https://leetcode.com/problems/path-sum/

namespace LeetCode.Problems;

public sealed class HasPathSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(HasPathSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,null,1]").Param(22).Result(true))
          .Add(it => it.ParamTree("[1,-2,-3,1,3,-2,null,-1]").Param(-1).Result(true))
          .Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,null,2]").Param(6).Result(false))
          .Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,null,1,null,null,3]").Param(22).Result(false))
          .Add(it => it.ParamTree("[1,2,3]").Param(5).Result(false))
          .Add(it => it.ParamTree("[]").Param(0).Result(false));

    private bool Solution(TreeNode root, int targetSum)
    {
        bool Dfs(TreeNode? node, int currentSum, int target)
        {
            if (node == null)
            {
                return false;
            }

            currentSum += node.val;
            if (node.left is null && node.right is null)
            {
                return currentSum == target;
            }

            return Dfs(node.left, currentSum, target) || Dfs(node.right, currentSum, target);
        }

        return Dfs(root, 0, targetSum);
    }
}