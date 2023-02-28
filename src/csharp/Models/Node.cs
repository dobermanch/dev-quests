// ReSharper disable InconsistentNaming
namespace LeetCode.Models;

/// <summary>
/// LeetCode version. DO NOT rename properties
/// </summary>
public class Node : IEquatable<Node>
{
    public Node() { }

    public Node(int val)
    {
        this.val = val;
    }

    public Node(int val, params Node[]? children)
    {
        this.val = val;
        this.children = children;
    }

    public Node(int val, Node left, Node right, Node next)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        this.next = next;
    }

    public int val { get; set; }

    public Node? left { get; set; }

    public Node? right { get; set; }

    public Node? next { get; set; }

    public IList<Node>? children { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var queue = new Queue<(Node node, int level)>();
        queue.Enqueue((this, 0));
        var prevLevel = 0;
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.node.next != null && prevLevel != current.level)
            {
                prevLevel = current.level;
                sb.Append(",#");
            }

            sb.Append($",{current.node.val}");

            if (current.node.left != null)
            {
                queue.Enqueue((current.node.left, current.level + 1));
            }

            if (current.node.right != null)
            {
                queue.Enqueue((current.node.right, current.level + 1));
            }
        }

        if (prevLevel > 0)
        {
            sb.Append(",#");
        }

        sb.Remove(0, 1);
        sb.Insert(0, "[");
        sb.Append("]");

        return sb.ToString();
    }

    public bool Equals(Node? other)
        => !ReferenceEquals(null, other) 
           && (ReferenceEquals(this, other) 
               || val == other.val
               && Equals(left, other.left)
               && Equals(right, other.right)
               && Equals(next, other.next)
               && (Equals(children, other.children)
                   || (children != null && other.children != null && children.SequenceEqual(other.children))));

    public override bool Equals(object? obj)
        => !ReferenceEquals(null, obj) &&
           (ReferenceEquals(this, obj) || obj.GetType() == GetType() && Equals((Node)obj));

    public override int GetHashCode()
        => HashCode.Combine(val, left, right, next, children);

    public static Node? Create(bool link = false, params int?[]? data)
    {
        if (data == null || !data.Any())
        {
            return null;
        }

        var root = new Node(data[0] ?? 0);
        var queue = new Queue<(Node node, int level)>();
        queue.Enqueue((root, 0));
        var index = 0;
        while (queue.Any())
        {
            var current = queue.Dequeue();

            if (link && queue.TryPeek(out var next) && next.level == current.level)
            {
                current.node.next = next.node;
            }

            if (++index < data.Length && data[index] != null)
            {
                current.node.left = new Node(data[index] ?? 0);
                queue.Enqueue((current.node.left, current.level + 1));
            }

            if (++index < data.Length && data[index] != null)
            {
                current.node.right = new Node(data[index] ?? 0);
                queue.Enqueue((current.node.right, current.level + 1));
            }
        }

        return root;
    }

    public static Node? Parse(string? input) => Create(input != null && input.Contains("#"), input.ToNullableArray());
}