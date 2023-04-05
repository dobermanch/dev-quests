//https://leetcode.com/problems/intersection-of-two-linked-lists/

namespace LeetCode.Problems;

public sealed class GetIntersectionNode : ProblemBase
{
    [Theory]
    [ClassData(typeof(GetIntersectionNode))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1), nameof(Solution2))
          .Add(it =>
           {
               var tail = ListNode.Parse("[8,4,5]")!;
               var headA = ListNode.Parse("[4,1]")!.AddLast(tail);
               var headB = ListNode.Parse("[5,6,1]")!.AddLast(tail);
               it.Param(headA).Param(headB).ResultListNode("[8,4,5]");
           })
           .Add(it =>
           {
               var tail = ListNode.Parse("[1,9,1]")!;
               var headA = ListNode.Parse("[4,1]")!.AddLast(tail);
               var headB = ListNode.Parse("[3]")!.AddLast(tail);
               it.Param(headA).Param(headB).ResultListNode("[1,9,1]");
           })
           .Add(it =>
           {
               var headA = ListNode.Parse("[2,6,4]")!;
               var headB = ListNode.Parse("[1,5")!;
               it.Param(headA).Param(headB).ResultListNode("[]");
           });

    private ListNode? Solution(ListNode? headA, ListNode? headB)
    {
        var nodeA = headA;
        var nodeB = headB;

        while (nodeA != nodeB)
        {
            nodeA = nodeA == null ? headB : nodeA.next;
            nodeB = nodeB == null ? headA : nodeB.next;
        }

        return nodeA;
    }

    private ListNode? Solution1(ListNode? headA, ListNode? headB)
    {
        void Modify(ListNode? node)
        {
            while (node != null)
            {
                node.val *= -1;
                node = node.next;
            }
        }

        Modify(headA);

        var node = headB;
        while (node != null)
        {
            if (node.val < 0)
            {
                break;
            }

            node = node.next;
        }

        Modify(headA);

        return node;
    }

    private ListNode? Solution2(ListNode headA, ListNode headB)
    {
        int GetLength(ListNode? node)
        {
            var length = 0;
            while (node != null)
            {
                length++;
                node = node.next;
            }

            return length;
        }

        ListNode? Skip(ListNode? node, int skip)
        {
            while (node != null && skip > 0)
            {
                skip--;
                node = node.next;
            }

            return node;
        }

        var lengthA = GetLength(headA);
        var lengthB = GetLength(headB);

        if (lengthA > lengthB)
        {
            headA = Skip(headA, lengthA - lengthB);
        }
        else
        {
            headB = Skip(headB, lengthB - lengthA);
        }

        while (headA != null || headB != null)
        {
            if (headA == headB)
            {
                return headA;
            }

            headA = headA.next;
            headB = headB.next;
        }

        return headA;
    }
}