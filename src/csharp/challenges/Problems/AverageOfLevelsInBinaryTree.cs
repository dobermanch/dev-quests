// https://leetcode.com/problems/average-of-levels-in-binary-tree

namespace LeetCode.Problems;

public sealed class AverageOfLevels : ProblemBase
{
    [Theory]
    [ClassData(typeof(AverageOfLevels))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamTree("[3,9,20,null,null,15,7]").ResultArray<double>("[3, 14.5, 11]"))
          .Add(it => it.ParamTree("[3,9,20,15,7]").ResultArray<double>("[3.00000,14.50000,11.00000]"));

    private IList<double> Solution(TreeNode root)
    {
        var queue = new Queue<(TreeNode node, int level)>();
        queue.Enqueue((root, 0));
        var result = new List<IList<double>>();

        while (queue.Any())
        {
            var (node, level) = queue.Dequeue();

            if (result.Count <= level)
            {
                result.Add(new List<double>());
            }

            result[level].Add(node.val);

            if (node.left != null)
            {
                queue.Enqueue((node.left, level + 1));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, level + 1));
            }
        }

        return result.Select(it => it.Average()).ToArray();
    }
}