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

    public bool IsCycleNode { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"[{val}");
        var current = next;
        while (current != null)
        {
            sb.Append($",{current.val}");
            if (current.IsCycleNode)
            {
                sb.Append("*");
            }

            current = current.next is not {IsCycleNode: true} ? current.next : null;
        }
        sb.Append("]");

        return sb.ToString();
    }

    public bool Equals(ListNode? other) 
        => !ReferenceEquals(null, other)
           && (ReferenceEquals(this, other) 
               || val == other.val 
               && ((next == null || !next.IsCycleNode) && Equals(next, other.next)));

    public override bool Equals(object? obj) 
        => !ReferenceEquals(null, obj) 
           && (ReferenceEquals(this, obj) 
               || obj.GetType() == GetType()
               && Equals((ListNode) obj));

    public override int GetHashCode()
        => HashCode.Combine(val, next);

    public static ListNode? Create(int? cycleAtPos = null, params int[]? data)
    {
        if (data == null || data.Length == 0)
        {
            return null;
        }

        var root = new ListNode(data[0]);
        ListNode? cycleTo = null;
        if (cycleAtPos == 0)
        {
            cycleTo = root;
        }

        var current = root;
        for (int i = 1; i < data.Length; i++)
        {
            current.next = new ListNode(data[i]);
            current = current.next;

            if (i == cycleAtPos)
            {
                cycleTo = current;
            }
        }

        if (cycleTo != null)
        {
            cycleTo.IsCycleNode = true;
            current.next = cycleTo;
        }

        var d = root.ToString();

        return root;
    }

    public static ListNode? Parse(string? input, int? cycleAtPos = null) => Create(cycleAtPos, input.ToArray());
}

public static class ListNodeExtensions
{
    public static ListNode AddLast(this ListNode? node, ListNode tail)
    {
        if (node is null)
        {
            return tail;
        }

        var temp = node;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = tail;

        return node;
    }
}
