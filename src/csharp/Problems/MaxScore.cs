//https://leetcode.com/problems/maximum-subsequence-score

namespace LeetCode.Problems;

public sealed class MaxScore : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxScore))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[2,1,14,12]").ParamArray("[11,7,13,6]").Param(3).Result(168L))
          .Add(it => it.ParamArray("[1,3,3,2]").ParamArray("[2,1,3,4]").Param(3).Result(12L))
          .Add(it => it.ParamArray("[4,2,3,1,1]").ParamArray("[7,5,10,9,6]").Param(1).Result(30L));

    private long Solution(int[] nums1, int[] nums2, int k)
    {
        Array.Sort(nums2, nums1, Comparer<int>.Create((x1, x2) => x2 - x1));

        var queue = new PriorityQueue<int, int>();

        long sum = 0;
        long res = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            queue.Enqueue(nums1[i], nums1[i]);

            sum += nums1[i];
            if (--k <= 0)
            {
                res = Math.Max(res, sum * nums2[i]);
                sum -= queue.Dequeue();
            }
        }

        return res;
    }
}