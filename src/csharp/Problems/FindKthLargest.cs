//https://leetcode.com/problems/kth-largest-element-in-an-array/

namespace LeetCode.Problems;

public sealed class FindKthLargest : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindKthLargest))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => AddSolutions(nameof(Solution1))
          .Add(it => it.ParamArray("[3,2,1,5,6,4]").Param(2).Result(5))
          .Add(it => it.ParamArray("[3,2,1,5,6,4]").Param(1).Result(6))
          .Add(it => it.ParamArray("[3,2,1,5,6,4]").Param(6).Result(1))
          .Add(it => it.ParamArray("[3,2,3,1,2,4,5,5,6]").Param(4).Result(4))
          .Add(it => it.ParamArray("[3]").Param(1).Result(3));

    private int Solution(int[] nums, int k)
    {
        int Select(int[] data, int left, int right, int target)
        {
            var index = left;
            for (var i = left; i < right; i++)
            {
                if (data[i] <= data[right])
                {
                    (data[index], data[i]) = (data[i], data[index]);
                    index++;
                }
            }

            (data[index], data[right]) = (data[right], data[index]);

            if (index > target)
            {
                return Select(nums, left, index - 1, target);
            }

            if (index < target)
            {
                return Select(nums, index + 1, right, target);
            }

            return data[index];
        }

        return Select(nums, 0, nums.Length - 1, nums.Length - k);
    }

    private int Solution1(int[] nums, int k)
    {
        var queue = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            queue.Enqueue(num, -num);
        }

        while (queue.Count > 0)
        {
            var num = queue.Dequeue();
            if (--k == 0)
            {
                return num;
            }
        }

        return 0;
    }
}