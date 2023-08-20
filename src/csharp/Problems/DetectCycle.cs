//https://leetcode.com/problems/linked-list-cycle-ii/

namespace LeetCode.Problems;

public sealed class DetectCycle : ProblemBase
{
    //[Theory]
    //[ClassData(typeof(DetectCycle))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it =>
        {
            var tail = new ListNode(-4);
            var head = new ListNode(2, new ListNode(0, tail));
            tail.next = head;
            var list = new ListNode(3, head);
            it.Param(list).Result(head);
            //it.ParamListNode("[3,2,0,-4]", 1).ResultListNode("[2,0,-4]");
        });

    private ListNode Solution(ListNode head)
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
    }
}