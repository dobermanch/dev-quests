//https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

namespace LeetCode.Problems;

public sealed class ZigzagLevelOrder : ProblemBase
{
    [Theory]
    [ClassData(typeof(ZigzagLevelOrder))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,9,20,null,null,15,7]").Result2dArray("[[3],[20,9],[15,7]]"))
          .Add(it => it.ParamTree("[3,9,20,8,10,15,7]").Result2dArray("[[3],[20,9],[8,10,15,7]]"))
          .Add(it => it.ParamTree("[1,3,2,4,5,6,7,15,14,13,12,11,10,9,8]").Result2dArray("[[1],[2,3],[4,5,6,7],[8,9,10,11,12,13,14,15]]"))
          .Add(it => it.ParamTree("[1]").Result2dArray("[[1]]"))
          .Add(it => it.ParamTree("[]").Result2dArray("[]"));

    private IList<IList<int>> Solution(TreeNode? root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<(TreeNode node, int level)>();
        queue.Enqueue((root, 0));
        while (queue.Any())
        {
            var (node, level) = queue.Dequeue();

            if (result.Count == level)
            {
                result.Add(new List<int>());
            }

            if (level % 2 == 0)
            {
                result[level].Add(node.val);
            }
            else
            {
                result[level].Insert(0, node.val);
            }

            if (node.left != null)
            {
                queue.Enqueue((node.left, level + 1));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, level + 1));
            }
        }

        return result;
    }
}