//https://leetcode.com/problems/can-place-flowers

namespace LeetCode.Problems;

public sealed class CanPlaceFlowers : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanPlaceFlowers))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,0,0,0,1]").Param(1).Result(true))
          .Add(it => it.ParamArray("[1,0,0,0,0]").Param(2).Result(true))
          .Add(it => it.ParamArray("[1,0,0,0,1]").Param(2).Result(false));

    private bool Solution(int[] flowerbed, int n)
    {
        var plot = 0;
        var left = n;

        while (left > 0 && plot < flowerbed.Length)
        {
            if (flowerbed[plot] == 1)
            {
                plot++;
            }
            else if ((plot == 0 || flowerbed[plot - 1] == 0)
                && (plot + 1 >= flowerbed.Length || flowerbed[plot + 1] == 0))
            {
                flowerbed[plot] = 1;
                plot++;
                left--;
            }

            plot++;
        }

        return left == 0;
    }
}