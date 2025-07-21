//https://leetcode.com/problems/binary-tree-level-order-traversal/

namespace LeetCode.Problems;

public sealed class LevelOrder : ProblemBase
{
    [Theory]
    [ClassData(typeof(LevelOrder))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,9,20,null,null,15,7]").Result2dArray("[[3],[9,20],[15,7]]"))
          .Add(it => it.ParamTree("[1]").Result2dArray("[[1]]"))
          .Add(it => it.ParamTree("[]").Result2dArray("[]"))
        ;

    private IList<IList<int>> Solution(TreeNode root)
    {
        if (root == null)
        {
            return Array.Empty<IList<int>>();
        }

        var queue = new Queue<(int level, TreeNode node)>();
        var levels = new List<IList<int>>();

        queue.Enqueue((0, root));
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (levels.Count <= current.level)
            {
                levels.Add(new List<int>());
            }
            levels[current.level].Add(current.node.val);

            var level = current.level + 1;
            if (current.node.left != null)
            {
                queue.Enqueue((level, current.node.left));
            }

            if (current.node.right != null)
            {
                queue.Enqueue((level, current.node.right));
            }
        }

        return levels;
    }
}