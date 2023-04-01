//https://leetcode.com/problems/merge-two-sorted-lists/

namespace LeetCode.Problems;

public sealed class MergeTwoLists : ProblemBase
{
    [Theory]
    [ClassData(typeof(MergeTwoLists))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,4]").ParamListNode("[1,3,4]").ResultListNode("[1,1,2,3,4,4]"))
          .Add(it => it.ParamListNode("[]").ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[]").ParamListNode("[0]").ResultListNode("[0]"));

    private ListNode? Solution(ListNode? list1, ListNode? list2)
    {
        var result = new ListNode();
        var current = result;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        current.next = list1 ?? list2;

        return result.next;
    }
}