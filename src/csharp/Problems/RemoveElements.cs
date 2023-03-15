//https://leetcode.com/problems/remove-linked-list-elements/

namespace LeetCode.Problems;

public sealed class RemoveElements : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveElements))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,6,3,4,5,6]").Param(6).ResultListNode("[1,2,3,4,5]"))
          .Add(it => it.ParamListNode("[1,2,6,3,4,5,6]").Param(1).ResultListNode("[2,6,3,4,5,6]"))
          .Add(it => it.ParamListNode("[7,7,7,7]").Param(7).ResultListNode("[]"))
          .Add(it => it.ParamListNode("[]").Param(1).ResultListNode("[]"));

    private ListNode? Solution(ListNode? head, int val)
    {
        var prev = head;
        var current = head;
        while (current != null)
        {
            if (current.val != val)
            {
                prev = current;
            }
            else
            {
                prev!.next = current.next;
            }

            current = current.next;
        }

        return head?.val == val ? head.next : head;
    }
}