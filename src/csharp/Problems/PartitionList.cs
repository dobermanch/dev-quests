// https://leetcode.com/problems/partition-list

namespace LeetCode.Problems;

public sealed class PartitionList : ProblemBase
{
    [Theory]
    [ClassData(typeof(PartitionList))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,4,3,2,5,2]").Param(3).ResultListNode("[1,2,2,4,3,5]"))
          .Add(it => it.ParamListNode("[2,1]").Param(2).ResultListNode("[1,2]"));

    private ListNode? Solution(ListNode? head, int x)
    {
        var node = head;
        var partition1 = new ListNode();
        var partition2 = new ListNode();
        var start = partition1;
        var tail = partition2;
        while (node != null)
        {
            if (node.val < x)
            {
                partition1.next = node;
                partition1 = partition1.next;
            }
            else
            {
                partition2.next = node;
                partition2 = partition2.next;
            }

            node = node.next;
        }

        partition2.next = null;
        partition1.next = tail.next;

        return start.next;
    }
}