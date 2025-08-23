// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii

namespace LeetCode.Problems;

public sealed class Connect2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(Connect2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamNode("[1,2,3,4,5,6,7]").ResultNode("[1,#,2,3,#,4,5,6,7,#]"))
          .Add(it => it.ParamNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]").ResultNode("[1,#,2,3,#,4,5,6,7,#,8,9,10,11,12,13,14,15,#]"))
          .Add(it => it.ParamNode("[]").ResultNode("[]"));

    private Node? Solution(Node? root)
    {
        if (root == null)
        {
            return root;
        }

        var queue = new Queue<(Node node, int level)>();
        queue.Enqueue((root, 0));

        while (queue.Any())
        {
            var (node, level) = queue.Dequeue();

            if (queue.TryPeek(out var next) && next.level == level)
            {
                node.next = next.node;
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

        return root;
    }
}