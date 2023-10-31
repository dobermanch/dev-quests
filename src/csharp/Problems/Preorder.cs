//https://leetcode.com/problems/n-ary-tree-preorder-traversal/

namespace LeetCode.Problems;

public sealed class Preorder : ProblemBase
{
    [Theory]
    [ClassData(typeof(Preorder))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it =>
               {
                   var node = new Node(1);
                   node.children!.Add(new Node(3, new Node(5), new Node(6)));
                   node.children.Add(new Node(2));
                   node.children.Add(new Node(4));

                   it.Param(node).ResultArray("[1,3,5,6,2,4]");
               });

    private IList<int> Solution(Node root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();
        var stack = new Stack<Node>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            result.Add(current.val);

            for (var i = current.children?.Count - 1; i >= 0; i--)
            {
                stack.Push(current.children![i.Value]);
            }
        }

        return result;
    }

    private IList<int> Solution1(Node root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        return new int[] { root.val }.Concat(root.children?.SelectMany(Solution1) ?? Array.Empty<int>()).ToArray();
    }
}