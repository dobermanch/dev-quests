//https://leetcode.com/problems/trapping-rain-water/

namespace LeetCode.Problems;

public sealed class Trap : ProblemBase
{
    [Theory]
    [ClassData(typeof(Trap))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[0,1,0,2,1,0,1,3,2,1,2,1]").Result(6))
          .Add(it => it.ParamArray("[4,9,4,5,3,2]").Result(1))
          .Add(it => it.ParamArray("[4,2,0,3,2,4,3,4]").Result(10))
          .Add(it => it.ParamArray("[5,4,1,2]").Result(1))
          .Add(it => it.ParamArray("[4,2,0,3,2,5]").Result(9))
        ;

    private int Solution(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var trap = 0;

        var maxL = 0;
        var maxR = 0;
        while (left <= right)
        {
            if (maxL < maxR)
            {
                if (maxL - height[left] > 0)
                {
                    trap += maxL - height[left];
                }
                maxL = Math.Max(maxL, height[left]);
                left++;
            }
            else
            {
                if (maxR - height[right] > 0)
                {
                    trap += maxR - height[right];
                }
                maxR = Math.Max(maxR, height[right]);
                right--;
            }
        }

        return trap;
    }
}