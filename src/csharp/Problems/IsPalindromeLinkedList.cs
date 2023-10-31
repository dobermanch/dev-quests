//https://leetcode.com/problems/palindrome-linked-list/

namespace LeetCode.Problems;

public sealed class IsPalindromeLinkedList : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsPalindromeLinkedList))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,2,1]").Result(true))
          .Add(it => it.ParamListNode("[1,2]").Result(false));

    private bool Solution(ListNode head)
    {
        var fast = head;
        var slow = head;
        ListNode? reverse = null;

        while (fast?.next != null)
        {
            fast = fast.next.next;

            var next = slow!.next;
            slow.next = reverse;
            reverse = slow;
            slow = next;
        }

        if (fast != null)
        {
            slow = slow!.next;
        }

        while (slow != null)
        {
            if (slow.val != reverse!.val)
            {
                return false;
            }

            slow = slow.next;
            reverse = reverse.next;
        }

        return true;
    }
}