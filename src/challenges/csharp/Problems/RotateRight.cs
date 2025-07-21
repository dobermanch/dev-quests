//https://leetcode.com/problems/rotate-list

namespace LeetCode.Problems;

public sealed class RotateRight : ProblemBase
{
    [Theory]
    [ClassData(typeof(RotateRight))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").Param(2).ResultListNode("[4,5,1,2,3]"))
          .Add(it => it.ParamListNode("[]").Param(0).ResultListNode("[]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5]").Param(5).ResultListNode("[1,2,3,4,5]"))
          .Add(it => it.ParamListNode("[0,1,2]").Param(4).ResultListNode("[2,0,1]"));

    private ListNode? Solution(ListNode? head, int k)
    {
        if (head is null || k == 0)
        {
            return head;
        }

        var count = 1;
        var lastNode = head;
        while (lastNode.next != null)
        {
            count++;
            lastNode = lastNode.next;
        }

        var newK = k % count;
        if (newK == 0)
        {
            return head;
        }

        var skip = count - newK;
        var node = head;
        while (--skip > 0)
        {
            node = node!.next;
        }

        var temp = node!.next;
        node.next = null;
        lastNode.next = head;

        return temp;
    }
}