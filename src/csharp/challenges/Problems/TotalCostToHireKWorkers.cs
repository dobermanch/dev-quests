//https://leetcode.com/problems/total-cost-to-hire-k-workers

namespace LeetCode.Problems;

public sealed class TotalCost : ProblemBase
{
    [Theory]
    [ClassData(typeof(TotalCost))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[2,2,2,2,2,2,1,4,5,5,5,5,5,2,2,2,2,2,2,2,2,2,2,2,2,2]").Param(7).Param(3).Result(13L))
          .Add(it => it.ParamArray("[1,2,4,1]").Param(3).Param(3).Result(4L))
          .Add(it => it.ParamArray("[58,25,71,74,73,65,84,91,91,84,74,74,74,72,25,58]").Param(11).Param(9).Result(669L))
          .Add(it => it.ParamArray("[211,169,4359,2335,3956,658,1371,1516,4637,2588,4166,250,4866,3122,1197,61,292,1616,4857,4067,1428,4912,3071,3108,2221,1932,4183,4101,727,2715,64,357,1186,2444,3766,3978,1962,1648,871,2961,1164,4792,1528,2064,2653,179,2780,3732,2881,1165,623,362,2371,1353,4219,4438,3765,4567,1372,4669,1496,3353,4147,33,4378,4634,1331,3014,3723,3271,433,1065,2345,4445,4077,2708,1303,2666,3311,1546,3078,4467,1683,414,4282,3510,478,2858,4805,1113,783,3999,2685,1025,3111,2394,2985,2693,1068,1806,690,4867,4178,1726,1680,1860,155,96,1500,4250,286,4145,771,1728,2677,353,1163,4876,2066,3910,2578,1298,3321,3236,1152,3140,2294,2200,69,3027,3675,3594,74,3575,2279,4874,1071,3085,1786,4596,1584,42,411,3962,2704,4411,1926,1300,4533,2119,3924,1034,128,911,4717,4767,1669,3669,2936,2099,3395,2487,2539,4722,122,642,4680,4813,708,4938,4156,1152,2789,699,4724,4159,1766,2662,492,2612,330,2010,458,161,794,2062,4281,717,3486,3331,474,4734,1869,4817,2796,1511,146,3857,3471,3674,45,519,3035,3830,4566,957,4705,3194,1524,2668,903,2833,2118,929,266,1177,3297,1681,400,2635,1962,1682,2116,603,1521]").Param(222).Param(2).Result(523545L))
          .Add(it => it.ParamArray("[48]").Param(1).Param(1).Result(48L))
          .Add(it => it.ParamArray("[17,12,10,2,7,2,11,20,8]").Param(3).Param(4).Result(11L))
          .Add(it => it.ParamArray("[50,80,34,9,86,20,67,94,65,82,40,79,74,92,84,37,19,16,85,20,79,25,89,55,67,84,3,79,38,16,44,2,54,58]").Param(7).Param(12).Result(95L));

    private long Solution(int[] costs, int k, int candidates)
    {
        long result = 0;
        var div = (float)Math.Pow(10, 5);
        var heap = new PriorityQueue<int, float>();

        var left = 0;
        var right = costs.Length - 1;
        while (left < candidates)
        {
            heap.Enqueue(left, left / div + costs[left++]);

            if (right >= candidates)
            {
                heap.Enqueue(right, right / div + costs[right--]);
            }
        }

        for (var i = 0; i < k; i++)
        {
            var costIndex = heap.Dequeue();

            result += costs[costIndex];

            if (costIndex < left && right >= left)
            {
                heap.Enqueue(left, left / div + costs[left++]);
            }
            else if (costIndex > right && right >= left)
            {
                heap.Enqueue(right, right / div + costs[right--]);
            }
        }

        return result;
    }
}