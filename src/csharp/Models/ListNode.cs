namespace LeetCode.Models;

/// <summary>
/// LeetCode version. DO NOT rename properties
/// </summary>
public class ListNode: IEquatable<ListNode>
{
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public int val { get; set; }

    public ListNode? next { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"[{val}");
        var current = next;
        while (current != null)
        {
            sb.Append($",{current.val}");
            current = current.next;
        }
        sb.Append("]");

        return sb.ToString();
    }

    public bool Equals(ListNode? other) 
        => !ReferenceEquals(null, other)
           && (ReferenceEquals(this, other) 
               || val == other.val 
               && Equals(next, other.next));

    public override bool Equals(object? obj) 
        => !ReferenceEquals(null, obj) 
           && (ReferenceEquals(this, obj) 
               || obj.GetType() == GetType()
               && Equals((ListNode) obj));

    public override int GetHashCode()
        => HashCode.Combine(val, next);

    public static ListNode? Create(params int[]? data)
    {
        if (data == null || data.Length == 0)
        {
            return null;
        }

        var root = new ListNode(data[0]);

        var current = root;
        for (int i = 1; i < data.Length; i++)
        {
            current.next = new ListNode(data[i]);
            current = current.next;
        }

        return root;
    }
}
