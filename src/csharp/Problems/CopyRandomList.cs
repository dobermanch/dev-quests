//https://leetcode.com/problems/copy-list-with-random-pointer/

namespace LeetCode.Problems;

public sealed class CopyRandomList : ProblemBase
{
    [Theory]
    [ClassData(typeof(CopyRandomList))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it =>
            {
                var node0 = new Node(7);
                var node1 = new Node(13);
                var node2 = new Node(11);
                var node3 = new Node(10);
                var node4 = new Node(1);

                node0.next = node1;
                node0.random = null;

                node1.next = node2;
                node1.random = node0;

                node2.next = node3;
                node2.random = node4;

                node3.next = node4;
                node3.random = node2;

                node4.next = null;
                node4.random = node0;

                it.Param(node0).Result(node0);
            })
          .Add(it =>
          {
              var node0 = new Node(1);
              var node1 = new Node(2);

              node0.next = node1;
              node0.random = node1;

              node1.next = null;
              node1.random = node1;

              it.Param(node0).Result(node0);
          })
          .Add(it =>
          {
              var node0 = new Node(3);
              var node1 = new Node(3);
              var node2 = new Node(3);

              node0.next = node1;
              node0.random = null;

              node1.next = node2;
              node1.random = node0;

              node2.next = null;
              node2.random = null;

              it.Param(node0).Result(node0);
          })
          .Add(it => it.ParamNode("[]", neighbors: true).ResultNode("[]"));

    private Node? Solution(Node? head)
    {
        var map = new Dictionary<Node, Node>();

        var node = head;
        while (node != null)
        {
            map.Add(node, new Node(node.val));
            node = node.next;
        }

        var root = new Node(0);
        var current = root;
        node = head;
        while (node != null)
        {
            current.next = map[node];
            current.next.next = node.next != null ? map[node.next] : null;
            current.next.random = node.random != null ? map[node.random] : null;

            node = node.next;
            current = current.next;
        }

        return root.next;
    }

    private Node? Solution1(Node? head)
    {
        Node? Clone(Node? source, IDictionary<Node, Node> map)
        {
            if (source == null)
            {
                return null;
            }

            if (map.TryGetValue(source, out var clone))
            {
                return clone;
            }

            clone = new Node(source.val);

            map.Add(source, clone);

            clone.next = Clone(source.next, map);
            clone.random = Clone(source.random, map);

            return clone;
        }

        return Clone(head, new Dictionary<Node, Node>());
    }
}