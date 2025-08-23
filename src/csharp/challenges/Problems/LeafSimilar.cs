//https://leetcode.com/problems/leaf-similar-trees

namespace LeetCode.Problems;

public sealed class LeafSimilar : ProblemBase
{
    [Theory]
    [ClassData(typeof(LeafSimilar))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,5,1,6,2,9,8,null,null,7,4]").ParamTree("[3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]").Result(true))
          .Add(it => it.ParamTree("[1,2,3]").ParamTree("[1,3,2]").Result(false));

    private bool Solution(TreeNode root1, TreeNode root2)
    {
        void Dfs(TreeNode? node, IList<int> result)
        {
            if (node == null) 
            {
                return;
            }

            Dfs(node.left, result);
            Dfs(node.right, result);

            if (node.left is null && node.right is null)
            {
                result.Add(node.val);
            }
        }

        var result1 = new List<int>();
        Dfs(root1, result1);
        
        var result2 = new List<int>();
        Dfs(root2, result2);

        return result1.SequenceEqual(result2);
    }
}