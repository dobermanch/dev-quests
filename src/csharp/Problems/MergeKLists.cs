//https://leetcode.com/problems/merge-k-sorted-lists/

namespace LeetCode.Problems;

public sealed class MergeKLists : ProblemBase
{
    [Theory]
    [ClassData(typeof(MergeKLists))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[[1,4,5],[1,3,4],[2,6]]").ResultListNode("[1,1,2,3,4,4,5,6]"))
          .Add(it => it.ParamListNode("[[1,2,2],[1,1,2]]").ResultListNode("[1,1,1,2,2,2]"))
          .Add(it => it.ParamListNode("[[1,2,2],[],[1,1,2]]").ResultListNode("[1,1,1,2,2,2]"))
          .Add(it => it.ParamListNode("[]").ResultListNode("[]"))
          .Add(it => it.ParamListNode("[[]]").ResultListNode("[]"));

    private ListNode? Solution(ListNode?[]? lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }

        ListNode? Merge(ListNode?[] toMerge, int index1, int index2)
        {
            if (index1 >= index2)
            {
                return toMerge[index1];
            }

            var diff = (index1 + index2) / 2;
            var list1 = Merge(toMerge, index1, diff);
            var list2 = Merge(toMerge, diff + 1, index2);

            var result = new ListNode();
            var current = result;
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            current.next = list1 ?? list2;

            return result.next;
        }

        return Merge(lists, 0, lists.Length - 1);
    }

    private ListNode? Solution1(ListNode?[]? lists)
    {
        var queue = new PriorityQueue<ListNode, int>();
        foreach (var list in lists ?? Array.Empty<ListNode>())
        {
            var current = list;
            while (current != null)
            {
                queue.Enqueue(current, current.val);
                current = current.next;
            }
        }

        var root = new ListNode(0);
        var node = root;
        while (queue.Count > 0)
        {
            node.next = queue.Dequeue();
            node = node.next;
        }

        node.next = null;

        return root.next;
    }
}