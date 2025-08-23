// https://leetcode.com/problems/reverse-linked-list-ii

namespace LeetCode.Problems;

public sealed class ReverseBetween : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseBetween))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19]").Param(1).Param(10).ResultListNode("[10,9,8,7,6,5,4,3,2,1,11,12,13,14,15,16,17,18,19]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19]").Param(4).Param(10).ResultListNode("[1,2,3,10,9,8,7,6,5,4,11,12,13,14,15,16,17,18,19]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5]").Param(2).Param(4).ResultListNode("[1,4,3,2,5]"))
          .Add(it => it.ParamListNode("[5]").Param(1).Param(1).ResultListNode("[5]"));

    private ListNode Solution(ListNode head, int left, int right)
    {
        var result = new ListNode(next: head);
        var count = 1;
        ListNode? headEnd = result;
        ListNode? reverse = null;
        ListNode? tailStart = head;
        ListNode? current = head;
        while (current != null)
        {
            var end = current.next;
            if (count < left)
            {
                headEnd = current;
                tailStart = current.next;
            }

            if (count >= left)
            {
                current.next = reverse;
                reverse = current;
            }

            if (count == right)
            {
                headEnd.next = reverse;
                tailStart!.next = end;
                break;
            }

            current = end;
            count++;
        }

        return result.next!;
    }
}