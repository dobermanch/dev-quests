//https://leetcode.com/problems/remove-nth-node-from-end-of-list/

namespace LeetCode.Problems;

public sealed class RemoveNthFromEnd : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveNthFromEnd))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").Param(2).ResultListNode("[1,2,3,5]"))
          .Add(it => it.ParamListNode("[1]").Param(1).ResultListNode("[]"))
          .Add(it => it.ParamListNode("[1,2]").Param(1).ResultListNode("[1]"))
        ;

    // Option 1
    private ListNode? Solution(ListNode head, int n)
    {
        ListNode? fast = head;
        ListNode? slow = head;

        var index = 0;
        while (fast.next != null)
        {
            fast = fast.next;
            if (++index > n)
            {
                slow = slow?.next;
            }
        }

        if (index == n - 1)
        {
            return head.next;
        }

        slow!.next = slow.next?.next;

        return head;
    }
}