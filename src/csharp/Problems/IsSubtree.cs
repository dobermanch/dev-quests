//https://leetcode.com/problems/subtree-of-another-tree/

namespace LeetCode.Problems;

public sealed class IsSubtree : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsSubtree))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[3,4,5,1,2]").ParamTree("[4,1,2]").Result(true))
          .Add(it => it.ParamTree("[3,4,5,1,null,2]").ParamTree("[3,1,2]").Result(false))
          .Add(it => it.ParamTree("[3,4,5,1,2,null,null,null,null,0]").ParamTree("[4,1,2]").Result(false))
          .Add(it => it.ParamTree("[3,4,5,4,2,null,null,1,2]").ParamTree("[4,1,2]").Result(true))
          .Add(it => it.ParamTree("[3,1,5,1,2,null,null,1,2]").ParamTree("[1,1,2]").Result(true))
          .Add(it => it.ParamTree("[3,1,5,1,2,null,null,1,2]").ParamTree("[1,1,2]").Result(true))
          .Add(it => it.ParamTree("[1]").ParamTree("[1]").Result(true))
          .Add(it => it.ParamTree("[1]").ParamTree("[1,2]").Result(false));

    private bool Solution(TreeNode root, TreeNode subRoot)
    {
        bool Dfs(TreeNode? node1, TreeNode? node2, bool checking)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 == null || node2 == null)
            {
                return false;
            }

            var result = node1.val == node2.val;
            if (result)
            {
                result &= Dfs(node1.left, node2.left, true);
                result &= Dfs(node1.right, node2.right, true);
            }

            if (!result && !checking)
            {
                result |= Dfs(node1.left, node2, false);
                result |= Dfs(node1.right, node2, false);
            }

            return result;
        }

        return Dfs(root, subRoot, false);
    }
}