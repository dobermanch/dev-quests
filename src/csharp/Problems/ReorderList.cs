//https://leetcode.com/problems/reorder-list/

namespace LeetCode.Problems;

public sealed class ReorderList : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReorderList))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10,11]").ResultListNode("[1,11,2,10,3,9,4,8,5,7,6]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10]").ResultListNode("[1,10,2,9,3,8,4,7,5,6]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14]").ResultListNode("[1,14,2,13,3,12,4,11,5,10,6,9,7,8]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]").ResultListNode("[1,15,2,14,3,13,4,12,5,11,6,10,7,9,8]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5]").ResultListNode("[1,5,2,4,3]"))
          .Add(it => it.ParamListNode("[1,2,3,4]").ResultListNode("[1,4,2,3]"))
          .Add(it => it.ParamListNode("[1,4]").ResultListNode("[1,4]"))
          .Add(it => it.ParamListNode("[1]").ResultListNode("[1]"));

    private ListNode Solution(ListNode head)
    {
        var slow = head;
        var fast = head.next;

        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
        }

        ListNode? reverse = null;
        while (slow != null)
        {
            var next = slow.next;
            slow.next = reverse;
            reverse = slow;
            slow = next;
        }

        var lead = head;
        var tail = reverse;
        while (tail.next != null)
        {
            var leadNext = lead.next;
            var tailNext = tail.next;

            lead.next = tail;
            tail.next = leadNext;

            lead = leadNext;
            tail = tailNext;
        }

        return head;
    }
}