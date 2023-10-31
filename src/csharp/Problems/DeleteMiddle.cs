//https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/

namespace LeetCode.Problems;

public sealed class DeleteMiddle : ProblemBase
{
    [Theory]
    [ClassData(typeof(DeleteMiddle))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,3,4,7,1,2,6]").ResultListNode("[1,3,4,1,2,6]"))
          .Add(it => it.ParamListNode("[1,2,3,4]").ResultListNode("[1,2,4]"))
          .Add(it => it.ParamListNode("[1,2,3]").ResultListNode("[1,3]"))
          .Add(it => it.ParamListNode("[2,1]").ResultListNode("[2]"))
          .Add(it => it.ParamListNode("[1]").ResultListNode("[]"));

    private ListNode? Solution(ListNode head)
    {
        if (head is null || head.next is null) 
        {
            return null;
        }

        var slow = head;
        var fast = head.next.next;

        while (fast != null && fast.next != null) 
        {
            slow = slow!.next;
            fast = fast.next.next;
        }

        slow!.next = slow.next!.next;

        return head;
    }
}