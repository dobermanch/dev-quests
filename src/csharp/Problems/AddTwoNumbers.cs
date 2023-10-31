//https://leetcode.com/problems/add-two-numbers/

namespace LeetCode.Problems;

public sealed class AddTwoNumbers : ProblemBase
{
    [Theory]
    [ClassData(typeof(AddTwoNumbers))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[2,4,3]").ParamListNode("[5,6,4]").ResultListNode("[7,0,8]"))
          .Add(it => it.ParamListNode("[0]").ParamListNode("[0]").ResultListNode("[0]"))
          .Add(it => it.ParamListNode("[9,9,9,9,9,9,9]").ParamListNode("[9,9,9,9]").ResultListNode("[8,9,9,9,0,0,0,1]"))
          .Add(it => it.ParamListNode("[2,4]").ParamListNode("[5,6,4]").ResultListNode("[7,0,5]"))
          .Add(it => it.ParamListNode("[2,4,9]").ParamListNode("[5,6]").ResultListNode("[7,0,0,1]"));

    private ListNode? Solution(ListNode l1, ListNode l2)
    {
        var node1 = l1;
        var node2 = l2;
        var result = new ListNode();
        var current = result;
        var carry = 0;
        while (node1 != null || node2 != null || carry > 0)
        {
            var num1 = node1 != null ? node1.val : 0;
            var num2 = node2 != null ? node2.val : 0;
            var sum = carry + num1 + num2;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
            node1 = node1?.next;
            node2 = node2?.next;
        }

        return result.next;
    }
}