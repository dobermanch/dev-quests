//https://leetcode.com/problems/middle-of-the-linked-list/

namespace LeetCode.Problems;

using LeetCode.Models;

public sealed class MiddleNode : ProblemBase
{
    public static void Run()
    {
        var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(2, new ListNode(1)))))));
    }

    private static ListNode Run(ListNode head)
    {
        var list = new List<ListNode>();
        var count = 0;

        var next = head;
        while(next != null)
        {
            list.Add(next);
            count++;
            next = next.next;
        }
        
        return list[count / 2];
    }
}