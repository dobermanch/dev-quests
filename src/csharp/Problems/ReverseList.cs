//https://leetcode.com/problems/reverse-linked-list/
namespace LeetCode.Problems;

public sealed class ReverseList : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseList))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").ResultListNode("[5,4,3,2,1]"))
          .Add(it => it.ParamListNode("[1,2]").ResultListNode("[2,1]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"));

    private ListNode? Solution(ListNode? head)
    {
        ListNode? result = null;
        var current = head;
        while (current != null)
        {
            var next = current.next;

            current.next = result;
            result = current;
            current = next;
        }

        return result;
    }
}