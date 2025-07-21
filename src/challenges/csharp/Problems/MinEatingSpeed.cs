//https://leetcode.com/problems/koko-eating-bananas/

namespace LeetCode.Problems;

public sealed class MinEatingSpeed : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinEatingSpeed))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[3,6,7,11]").Param(8).Result(4))
          .Add(it => it.ParamArray("[312884470]").Param(312884469).Result(2))
          .Add(it => it.ParamArray("[1000000000]").Param(2).Result(500000000))
          .Add(it => it.ParamArray("[805306368,805306368,805306368]").Param(1000000000).Result(3))
          .Add(it => it.ParamArray("[980628391,681530205,734313996,168632541]").Param(819870953).Result(4))
          .Add(it => it.ParamArray("[312884470]").Param(968709470).Result(1))
          .Add(it => it.ParamArray("[3,6,7,11,3,444,5,3,4,45,66]").Param(15).Result(89))
          .Add(it => it.ParamArray("[30,11,23,4,20]").Param(12).Result(10))
          .Add(it => it.ParamArray("[30]").Param(1).Result(30))
          .Add(it => it.ParamArray("[30]").Param(2).Result(15))
          .Add(it => it.ParamArray("[30,11,23,4,20]").Param(5).Result(30))
          .Add(it => it.ParamArray("[30,11,23,4,20]").Param(6).Result(23));

    private int Solution(int[] piles, int h)
    {
        var left = 1;
        var right = 1;

        for (int i = 0; i < piles.Length; i++)
        {
            right = Math.Max(right, piles[i]);
        }

        while (left < right)
        {
            var mid = (right + left) / 2;
            var count = 0L;
            for (int i = 0; i < piles.Length; i++)
            {
                count += (long)Math.Ceiling(piles[i] / (double)mid);
            }

            if (count > h)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}