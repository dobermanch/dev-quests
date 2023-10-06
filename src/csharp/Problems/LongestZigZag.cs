//https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree
namespace LeetCode.Problems;

public sealed class LongestZigZag : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestZigZag))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[10,7,10,7,6,2,5,3,4,6,2,7,7,9,null,69,5,7,5,null,null,5,5,2,5,1,null,null,2,10,4,3,null,4,1,null,2,6,null,3,8,null,2,7,1,null,null,null,null,10,10,4,2,null,null,10,1,null,1,null,null,null,null,null,3,null,null,3,4,null,8,null,6,6,10,8,null,4,2,10,10,9,7,10,1,null,9,null,null,4,null,null,null,4,null,null,null,9,null,5,2,3,2,10,9,null,7,null,1,4,null,3,null,null,9,null,null,null,null,null,null,null,null,null,null,1,2,null,4,null,null,6,null,6,6,null,null,null,null,1,null,null,null,2,8,null,null,null,null,5,8,4,2,null,null,null,null,6,9,5,5,null,null,5,null,1,2,null,null,null,null,null,null,null,null,null,null,null,null,7,null,null,null,null,4,null,null,6,null,3,null,null,null,1,2]").Result(6))
          .Add(it => it.ParamTree("[1,null,2,3,4,null,null,null,5]").Result(2))
          .Add(it => it.ParamTree("[0,null,1,5,2,null,null,3,6,null,4,null,null,null,7]").Result(3))
          .Add(it => it.ParamTree("[1,2,7,null,3,null,null,4,6,null,5]").Result(4))
          .Add(it => it.ParamTree("[1]").Result(0));

    private int Solution(TreeNode? root)
    {
        int Dfs(TreeNode? node, int depth, bool goLeft)
        {
            if (node is null) 
            {
                return depth - 1;
            }
            
            var current = Dfs(goLeft ? node.left : node.right, depth + 1, !goLeft);
            var alternative = Dfs(goLeft ? node.right : node.left, 1, goLeft);
            
            return Math.Max(current, alternative);
        }

        return Dfs(root, 0, true);
    }
}