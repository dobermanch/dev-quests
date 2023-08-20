//https://leetcode.com/problems/odd-even-linked-list/

namespace LeetCode.Problems;

public sealed class OddEvenList : ProblemBase
{
    [Theory]
    [ClassData(typeof(OddEvenList))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").ResultListNode("[1,3,5,2,4]"))
          .Add(it => it.ParamListNode("[2]").ResultListNode("[2]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[2,1,3,5,6,4,7]").ResultListNode("[2,3,6,7,1,5,4]"))
          .Add(it => it.ParamListNode("[2,1,3,5,6,4]").ResultListNode("[2,3,6,1,5,4]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,8,9,6,4,5]").ResultListNode("[1,3,5,9,4,2,4,8,6,5]"));

    private ListNode Solution(ListNode head)
    {
        var lead = head;
        var skip = head?.next;
        var next = head?.next?.next;

        while(next != null)
        {
            var temp = lead.next;
            skip.next = next.next;
            lead.next = next;
            lead.next.next = temp;

            lead = lead.next;
            next = skip.next?.next;
            skip = skip.next;
        }

        return head;
    }
}