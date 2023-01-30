using LeetCode.Models;

namespace LeetCode.Problems;

public sealed class LevelOrder : ProblemBase
{
    public static void Run()
    {
        var node = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
        var d = Run(node);
    }

    private static IList<IList<int>> Run(TreeNode root)
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