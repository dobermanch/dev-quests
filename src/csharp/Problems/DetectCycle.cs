//https://leetcode.com/problems/linked-list-cycle-ii/

namespace LeetCode.Problems;

public sealed class DetectCycle : ProblemBase
{
    public static void Run()
    {
        var tail = new ListNode(5);
        var head = new ListNode(2, new ListNode(3, new ListNode(4, tail)));
        var list = new ListNode(1, head);
        //var list = new ListNode(1, tail);
        //tail.next = head;
        var d = Run(list);
    }

    private static ListNode Run(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                while (head != slow)
                {
                    head = head.next;
                    slow = slow.next;
                }

                return head;
            }
        }

        return null;
        // var map = new HashSet<ListNode>();
        // var current = head;
        // while (current != null) 
        // {
        //     if (map.Contains(current)){
        //         return current;
        //     }

        //     map.Add(current);
        //     current = current.next;
        // }

        // return null;
    }
}