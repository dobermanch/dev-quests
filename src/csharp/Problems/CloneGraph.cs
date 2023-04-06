//https://leetcode.com/problems/clone-graph/

namespace LeetCode.Problems;

public sealed class CloneGraph : ProblemBase
{
    [Theory]
    [ClassData(typeof(CloneGraph))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it =>
            {
                var node1 = new Node(1);
                var node2 = new Node(2);
                var node3 = new Node(3);
                var node4 = new Node(4);

                node1.neighbors!.Add(node2);
                node1.neighbors!.Add(node4);

                node2.neighbors!.Add(node1);
                node2.neighbors!.Add(node3);

                node3.neighbors!.Add(node2);
                node3.neighbors!.Add(node4);

                node4.neighbors!.Add(node1);
                node4.neighbors!.Add(node3);

                it.Param(node1).Result(node1);
            })
          .Add(it => it.ParamNode("[[]]", neighbors: true).ResultNode("[[]]", neighbors: true))
          .Add(it => it.ParamNode("[]", neighbors: true).ResultNode("[]", neighbors: true))
        ;

    private Node? Solution(Node? node)
    {
        Node Clone(Node source, IDictionary<int, Node> map)
        {
            if (map.ContainsKey(source.val))
            {
                return map[source.val];
            }

            var clone = new Node
            {
                val = source.val
            };

            map.Add(source.val, clone);

            foreach (var neighbor in source.neighbors)
            {
                clone.neighbors.Add(Clone(neighbor, map));
            }

            return clone;
        }

        return node is null ? null : Clone(node, new Dictionary<int, Node>());
    }
}