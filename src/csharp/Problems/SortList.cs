//https://leetcode.com/problems/sort-list/

namespace LeetCode.Problems;

public sealed class SortList : ProblemBase
{
    [Theory]
    [ClassData(typeof(SortList))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param<ListNode>(4,2,1,3).Result<ListNode>(1,2,3,4))
          .Add(it => it.Param<ListNode>(-1, 5, 3, 4, 0).Result<ListNode>(-1, 0, 3, 4, 5))
          .Add(it => it.Param<ListNode>(2).Result<ListNode>(2))
          .Add(it => it.Param<ListNode>().Result<ListNode>());

    private ListNode? Solution(ListNode head)
    {
        return Sort(head);
    }

    private ListNode? Sort(ListNode? head)
    {
        if (head?.next == null)
        {
            return head;
        }

        var slow = head;
        var fast = head.next;
        while (fast?.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        var mid = slow.next;
        slow.next = null;

        var left = Sort(head);
        var right = Sort(mid);

        return Merge(left, right);
    }

    private ListNode Merge(ListNode? left, ListNode? right)
    {
        var result = new ListNode();
        var merge = result;
        while (merge != null)
        {
            if (left == null || right == null)
            {
                merge.next = left ?? right;
                break;
            }
            if (left.val < right.val)
            {
                merge.next = left;
                left = left.next;
            }
            else
            {
                merge.next = right;
                right = right.next;
            }

            merge = merge.next;
        }

        return result.next;
    }
}