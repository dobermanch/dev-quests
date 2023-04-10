//https://leetcode.com/problems/sliding-window-maximum/

namespace LeetCode.Problems;

public sealed class MaxSlidingWindow : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxSlidingWindow))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[9,10,9,-7,-4,-8,2,-6]").Param(5).ResultArray("[10,10,9,2]"))
          .Add(it => it.ParamArray("[-7,-8,7,5,7,1,6,0]").Param(4).ResultArray("[7,7,7,7,7]"))
          .Add(it => it.ParamArray("[1,3,-1,-3,5,3,6,7,3,4,3,2,3,4,5,2,8,5,2,9,5,8]").Param(4).ResultArray("[3,5,5,6,7,7,7,7,4,4,4,5,5,8,8,8,9,9,9]"))
          .Add(it => it.ParamArray("[1,3,-1,-3,5,3,6,7,3,4,15,2,8,5,2,9,5,8]").Param(6).ResultArray("[5,6,7,7,7,15,15,15,15,15,15,9,9]"))
          .Add(it => it.ParamArray("[1,3,-1,-3,5,3,6,7]").Param(3).ResultArray("[3,3,5,5,6,7]"))
          .Add(it => it.ParamArray("[1]").Param(1).ResultArray("[1]"));

    private int[] Solution(int[] nums, int k)
    {
        var queue = new PriorityQueue<int, int>();

        var result = new int[nums.Length - k + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            while (queue.Count > 0 && i - k >= queue.Peek())
            {
                queue.Dequeue();
            }

            queue.Enqueue(i, -nums[i]);

            if (i >= k - 1)
            {
                result[i - (k - 1)] = nums[queue.Peek()];
            }
        }

        return result;
    }
}