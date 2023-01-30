using LeetCode.Models;

namespace LeetCode.Problems;

public sealed class MergeTwoLists : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(3, new ListNode(4))));
        var d = Run(new ListNode(2, new ListNode(4)), new ListNode(1, new ListNode(3, new ListNode(4))));
        //var d = Run(null, null);
        //var d = Run(null, new ListNode(0));
        //var d = Run(new ListNode(2), new ListNode(1));
    }

    private static ListNode Run(ListNode list1, ListNode list2)
    {
        if (list1 == null)
        {
            return list2;
        }

        if (list2 == null)
        {
            return list1;
        }

        var result = new ListNode();
        var current = result;
        do
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }
        while (list1 != null && list2 != null);

        current.next = list1 == null ? list2 : list1;

        return result.next;
    }
}