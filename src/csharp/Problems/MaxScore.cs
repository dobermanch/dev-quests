//https://leetcode.com/problems/maximum-subsequence-score

using System.Collections.Generic;

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
        int min = 0;
        long res = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            queue.Enqueue(nums1[i], nums1[i]);

            sum += nums1[i];
            min = nums2[i];

            if (--k <= 0)
            {
                res = Math.Max(res, sum * min);
                sum -= queue.Dequeue();
            }
        }

        //for (int i = k; i < lst.Count; i++)
        //{
        //    sum += lst[i].Item1 - pq.Dequeue();
        //    pq.Enqueue(lst[i].Item1, lst[i].Item1);
        //    min = lst[i].Item2;
        //    res = Math.Max(res, sum * min);
        //}

        return res;
    }

    private long Solution2(int[] nums1, int[] nums2, int k)
    {
        void Search(int index, IList<int> temp1, IList<int> temp2, IList<int> result)
        {
            if (temp1.Count == k)
            {
                result.Add(temp1.Sum() * temp2.Min());
                return;
            }

            if (index >= nums1.Length)
            {
                return;
            }

            temp1.Add(nums1[index]);
            temp2.Add(nums2[index]);
            Search(index + 1, temp1, temp2, result);

            temp1.RemoveAt(temp1.Count - 1);
            temp2.RemoveAt(temp2.Count - 1);

            Search(index + 1, temp1, temp2, result);
        }

        var result = new List<int>();
        Search(0, new List<int>(), new List<int>(), result);

        return result.Max();
    }
}