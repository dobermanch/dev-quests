//https://leetcode.com/problems/remove-duplicates-from-sorted-list/

namespace LeetCode.Problems;

public sealed class DeleteDuplicates : ProblemBase
{
    [Theory]
    [ClassData(typeof(DeleteDuplicates))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,1,2]").ResultListNode("[1,2]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[1,1,2,3,3]").ResultListNode("[1,2,3]"));

    private ListNode? Solution(ListNode? head)
    {
        var prev = head;
        var current = head?.next;
        while (current != null)
        {
            if (prev!.val == current.val)
            {
                prev.next = current.next;
            }
            else
            {
                prev = current;
            }

            current = current.next;
        }

        return head;
    }
}