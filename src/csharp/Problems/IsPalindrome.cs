//https://leetcode.com/problems/palindrome-linked-list/

using LeetCode.Models;

namespace LeetCode.Problems;

public sealed class IsPalindrome : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(2, new ListNode(1)))))));
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1)))));
        var d = Run(new ListNode(1, new ListNode(2)));

        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(2, new ListNode(1))))));
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(2))));
        //var d = Run(new ListNode(1));

        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(2))));
        // var d = Run(new ListNode(1, new ListNode(2, new ListNode(1))));
    }

    private static bool Run(ListNode head)
    {
        var fast = head;
        var slow = head;
        ListNode reverse = null;

        while (fast?.next != null)
        {
            fast = fast.next.next;

            var next = slow.next;
            slow.next = reverse;
            reverse = slow;
            slow = next;
        }

        if (fast != null)
        {
            slow = slow.next;
        }

        while (slow != null)
        {
            if (slow.val != reverse.val)
            {
                return false;
            }

            slow = slow.next;
            reverse = reverse.next;
        }

        return true;
    }
}