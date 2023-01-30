using LeetCode.Models;

namespace LeetCode.Problems;

public sealed class Preorder : ProblemBase
{
    public static void Run()
    {
        var node = new Node(1, new Node(2), new Node(3, new Node(6), new Node(7, new Node(11, new Node(14)))), new Node(4, new Node(8, new Node(12))), new Node(5, new Node(9, new Node(13)), new Node(10)));
        var d = Run(node);
    }

    private static IList<int> Run(Node root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        return new int[] { root.val }.Concat(root.children?.SelectMany(Run) ?? Array.Empty<int>()).ToArray();

        // var result = new List<int>();
        // var stack = new Stack<Node>();
        // stack.Push(root);
        // while(stack.Count > 0)
        // {
        //     var current = stack.Pop();
        //     result.Add(current.val);

        //     for(var i = current.children?.Count - 1; i >= 0; i--)
        //     {
        //         stack.Push(current.children[i.Value]);
        //     }
        // }

        // return result;
    }
}