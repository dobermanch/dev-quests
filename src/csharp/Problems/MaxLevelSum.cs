//https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree

namespace LeetCode.Problems;

public sealed class MaxLevelSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxLevelSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[1,7,0,7,-8,null,null]").Result(2))
          .Add(it => it.ParamTree("[989,null,10250,98693,-89388,null,null,null,-32127]").Result(2));

    private int Solution(TreeNode root)
    {
       var queue = new Queue<(TreeNode node, int level)>();
        queue.Enqueue((root, 1));

        var levels = new Dictionary<int, int>();
        while (queue.Count > 0)
        {
            var (node, level) = queue.Dequeue();
            levels[level] = levels.GetValueOrDefault(level) + node.val;

            if (node.left != null)
            {
                queue.Enqueue((node.left, level + 1));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, level + 1));
            }
        }

        return levels.OrderByDescending(it => it.Value).Select(it => it.Key).First();
    }
}