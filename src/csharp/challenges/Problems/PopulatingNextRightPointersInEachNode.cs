//https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

namespace LeetCode.Problems;

public sealed class Connect : ProblemBase
{
    [Theory]
    [ClassData(typeof(Connect))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamNode("[1,2,3,4,5,6,7]").ResultNode("[1,#,2,3,#,4,5,6,7,#]"))
          .Add(it => it.ParamNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]").ResultNode("[1,#,2,3,#,4,5,6,7,#,8,9,10,11,12,13,14,15,#]"))
          .Add(it => it.ParamNode("[]").ResultNode("[]"));

    private Node? Solution(Node? root)
    {
        var node = root;

        while (node != null)
        {
            var current = node;
            while (current != null)
            {
                if (current.left != null)
                {
                    current.left.next = current.right;
                }

                if (current.right != null)
                {
                    current.right.next = current.next?.left;
                }

                current = current.next;
            }

            node = node.left;
        }

        return root;
    }

    private Node? Solution1(Node? root)
    {
        void Populate(Node? node)
        {
            if (node == null)
            {
                return;
            }

            if (node.left != null)
            {
                node.left.next = node.right;
                Populate(node.left);
            }

            if (node.right != null)
            {
                node.right.next = node.next?.left;
                Populate(node.right);
            }
        }

        Populate(root);

        return root;
    }

    private Node? Solution2(Node? root)
    {
        if (root == null)
        {
            return root;
        }

        var queue = new Queue<(Node node, int level)>();
        queue.Enqueue((root, 0));

        while (queue.Any())
        {
            var current = queue.Dequeue();

            if (queue.TryPeek(out var next) && next.level == current.level)
            {
                current.node.next = next.node;
            }

            if (current.node.left != null)
            {
                queue.Enqueue((current.node.left, current.level + 1));
            }

            if (current.node.right != null)
            {
                queue.Enqueue((current.node.right, current.level + 1));
            }
        }

        return root;
    }
}