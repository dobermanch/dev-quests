public class RemoveNthFromEnd {

    public static void Run(){
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);
        //var d = Run(new ListNode(1), 1);
        //var d = Run(new ListNode(1, new ListNode(2)), 1);
        var d = Run(new ListNode(1, new ListNode(2)), 2);
        //var d = Run(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5,new ListNode(6,new ListNode(7,new ListNode(8,new ListNode(9,new ListNode(10)))))))))), 3);
    }

// Option 1
    private static ListNode Run(ListNode head, int n)
    {
        ListNode fast = head;
        ListNode slow = head;

        var index = 0;
        while(fast.next != null)
        {
            fast = fast.next;
            if (++index > n)
            {
                slow = slow.next;
            }
        }

        if (index == n - 1)
        {
            return head.next;
        }

        slow.next = slow.next?.next;

        return head;
    }

// Option 1
    private static ListNode Run1(ListNode head, int n)
    {
        var temp = new List<ListNode>();

        var current = head;
        while(current != null)
        {
            temp.Add(current);
            current = current.next;
        }

        if (n == temp.Count)
        {
            head = temp[^n].next;
        }
        else
        {
            temp[^(n + 1)].next = n - 1 > 0 ? temp[^n].next : null;
        }

        return head;
    }
}