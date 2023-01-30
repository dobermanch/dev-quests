namespace LeetCode.Models;

/// <summary>
/// LeetCode version. DO NOT rename properties
/// </summary>
public class Node
{
    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, params Node[] _children)
    {
        val = _val;
        children = _children;
    }

    public int val { get; set; }

    public IList<Node> children { get; set; }
}