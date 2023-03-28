//https://leetcode.com/problems/add-strings/

namespace LeetCode.Problems;

public sealed class DeleteDuplicates2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(DeleteDuplicates2))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,3,4,4,5]").ResultListNode("[1,2,5]"))
          .Add(it => it.ParamListNode("[0,1,2,2,3,4]").ResultListNode("[0,1,3,4]"))
          .Add(it => it.ParamListNode("[1,1]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[1,1,1,2,3]").ResultListNode("[2,3]"));

    private ListNode? Solution(ListNode? head)
    {
        var prev = new ListNode(next: head);
        head = prev;
        var current = head.next;
        bool remove = false;
        while (current != null)
        {
            if (current.val == current.next?.val)
            {
                prev.next = current.next;
                remove = true;
            }
            else if (remove)
            {
                prev.next = current.next;
                remove = false;
            }
            else
            {
                prev = current;
            }

            current = current.next;
        }

        return head.next;
    }
}