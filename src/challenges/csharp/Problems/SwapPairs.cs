//https://leetcode.com/problems/swap-nodes-in-pairs

namespace LeetCode.Problems;

public sealed class SwapPairs : ProblemBase
{
    [Theory]
    [ClassData(typeof(SwapPairs))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4]").ResultListNode("[2,1,4,3]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6]").ResultListNode("[2,1,4,3,6,5]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[1]").ResultListNode("[1]"));

    private ListNode? Solution(ListNode? head)
    {
        var result = new ListNode(next: head);
        var prev = result;
        var current = prev.next;
        while (current?.next != null)
        {
            var temp = current.next!.next;
            prev.next = current.next;
            prev.next!.next = current;
            current.next = temp;

            current = current.next;
            prev = prev.next.next;
        }

        return result.next;
    }
}