//https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/

namespace LeetCode.Problems;

public sealed class PairSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(PairSum))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5,6,7,8,9,10]").Result(11))
          .Add(it => it.ParamListNode("[5,4,2,1]").Result(6))
          .Add(it => it.ParamListNode("[4,2,2,3]").Result(7))
          .Add(it => it.ParamListNode("[1,100000]").Result(100001));

    private int Solution(ListNode? head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null) 
        {
            slow = slow!.next;
            fast = fast.next.next;
        }

        ListNode? tail = null;
        while (slow != null)
        {
            var next = slow.next;
            slow.next = tail;
            tail = slow;
            slow = next;
        }

        var max = 0;

        while (tail != null)
        {
            max = Math.Max(max, tail.val + head!.val);
            head = head.next;
            tail = tail.next;
        }

        return max;
    }
}