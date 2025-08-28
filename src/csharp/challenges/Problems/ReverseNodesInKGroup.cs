//https://leetcode.com/problems/reverse-nodes-in-k-group/

namespace LeetCode.Problems;

public sealed class ReverseKGroup : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseKGroup))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").Param(2).ResultListNode("[2,1,4,3,5]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5]").Param(3).ResultListNode("[3,2,1,4,5]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6]").Param(2).ResultListNode("[2,1,4,3,6,5]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6]").Param(3).ResultListNode("[3,2,1,6,5,4]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8]").Param(3).ResultListNode("[3,2,1,6,5,4,7,8]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9]").Param(3).ResultListNode("[3,2,1,6,5,4,9,8,7]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8]").Param(4).ResultListNode("[4,3,2,1,8,7,6,5]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5]").Param(1).ResultListNode("[1,2,3,4,5]"))
          .Add(it => it.ParamListNode("[1]").Param(1).ResultListNode("[1]"));

    private ListNode Solution(ListNode head, int k)
    {
        (ListNode? group, ListNode? tail) Reverse(ListNode? node, int length)
        {
            ListNode? group = null;
            while (node != null && length > 0)
            {
                var next = node.next;

                node.next = group;
                group = node;
                node = next;
                length--;
            }

            return length > 0 ? Reverse(group, k - length) : (group, node);
        }

        var result = new ListNode();

        var tail = head;
        head = result;
        while (tail != null)
        {
            var lastElement = tail;

            var node = Reverse(tail, k);
            tail = node.tail;

            head.next = node.group;
            head = lastElement;
        }

        return result.next!;
    }
}