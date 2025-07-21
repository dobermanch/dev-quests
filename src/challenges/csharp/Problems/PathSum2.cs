//https://leetcode.com/problems/path-sum-ii/

namespace LeetCode.Problems;

public sealed class PathSum2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(PathSum2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,5,1]").Param(22).Result2dArray("[[5,4,11,2],[5,8,4,5]]"))
          .Add(it => it.ParamTree("[5,4,8,11,null,13,4,7,2,null,null,5,1,null,null,1]").Param(22).Result2dArray("[[5,8,4,5]]"))
          .Add(it => it.ParamTree("[1,2,3]").Param(5).Result2dArray("[]"))
          .Add(it => it.ParamTree("[1,2]").Param(0).Result2dArray("[]"));

    private IList<IList<int>> Solution(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();
        void Dfs(TreeNode? node, int currentSum, int target, IList<int> temp)
        {
            if (node == null)
            {
                return;
            }

            temp.Add(node.val);

            currentSum += node.val;
            if (node.left is null && node.right is null)
            {
                if (currentSum == target)
                {
                    result.Add(temp.ToArray());
                }

                temp.RemoveAt(temp.Count - 1);
                return;
            }

            Dfs(node.left, currentSum, target, temp);
            Dfs(node.right, currentSum, target, temp);

            temp.RemoveAt(temp.Count - 1);
        }

        Dfs(root, 0, targetSum, new List<int>());

        return result;
    }
}