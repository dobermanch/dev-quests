namespace LeetCode.Models;

/// <summary>
/// LeetCode version. DO NOT rename properties
/// </summary>
public class TreeNode: IEquatable<TreeNode>
{
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public int val { get; set; }

    public TreeNode? left { get; set; }

    public TreeNode? right { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            sb.Append($",{node.val}");
            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }

        sb.Remove(0, 1);
        sb.Insert(0, "[");
        sb.Append("]");

        return sb.ToString();
    }

    public bool Equals(TreeNode? other) 
        => !ReferenceEquals(null, other) 
           && (ReferenceEquals(this, other) 
               || val == other.val 
               && Equals(left, other.left) 
               && Equals(right, other.right));

    public override bool Equals(object? obj) 
        => !ReferenceEquals(null, obj) 
           && (ReferenceEquals(this, obj)
               || obj.GetType() == GetType() 
               && Equals((TreeNode) obj));

    public override int GetHashCode() 
        => HashCode.Combine(val, left, right);

    public static TreeNode? Create(params int?[] data)
    {
        if (data == null || !data.Any())
        {
            return null;
        }

        var root = new TreeNode(data[0] ?? 0);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var index = 0;
        while (queue.Any() && index < data.Length)
        {
            var node = queue.Dequeue();
            if (++index < data.Length && data[index] != null)
            {
                node.left = new TreeNode(data[index] ?? 0);
                queue.Enqueue(node.left);
            }

            if (++index < data.Length && data[index] != null)
            {
                node.right = new TreeNode(data[index] ?? 0);
                queue.Enqueue(node.right);
            }
        }

        return root;
    }

    public static TreeNode? Parse(string? input) => Create(input.ToArray<int?>());
}