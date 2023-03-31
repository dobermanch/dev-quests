// https://leetcode.com/problems/linked-list-cycle/

namespace LeetCode.Problems;

public sealed class HasCycle : ProblemBase
{
    [Theory]
    [ClassData(typeof(HasCycle))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamListNode("[3,2,0,-4]", 1).Result(true))
          .Add(it => it.ParamListNode("[1,2]", 0).Result(true))
          .Add(it => it.ParamListNode("[1,2,3,4,5,6,7]", -1).Result(false))
          .Add(it => it.ParamListNode("[1]", -1).Result(false))
          .Add(it => it.ParamListNode("[]", -1).Result(false));

    private bool Solution(ListNode? head)
    {
        var slow = head;
        var fast = head?.next;

        while (slow != null && fast != null)
        {
            if (slow.Equals(fast))
            {
                return true;
            }

            slow = slow.next;
            fast = fast.next?.next;
        }

        return false;
    }
}