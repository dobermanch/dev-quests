//https://leetcode.com/problems/middle-of-the-linked-list/

namespace LeetCode.Problems;

using LeetCode.Models;

public sealed class MiddleNode : ProblemBase
{
    [Theory]
    [ClassData(typeof(MiddleNode))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[1,2,3,4,5]").ResultListNode("[3,4,5]"))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6]").ResultListNode("[4,5,6]"))
        ;

    private ListNode Solution(ListNode head)
    {
        var list = new List<ListNode>();
        var count = 0;

        var next = head;
        while(next != null)
        {
            list.Add(next);
            count++;
            next = next.next;
        }
        
        return list[count / 2];
    }
}