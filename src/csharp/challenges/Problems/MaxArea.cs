//https://leetcode.com/problems/container-with-most-water/

namespace LeetCode.Problems;

public sealed class MaxArea : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxArea))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,8,6,2,5,4,8,3,7]").Result(49))
          .Add(it => it.ParamArray("[1,1]").Result(1));

    private int Solution(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var max = 0;

        while (left < right)
        {
            var maxHeight = Math.Min(height[left], height[right]);
            var width = right - left;
            var capacity = maxHeight * width;

            max = Math.Max(max, capacity);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return max;
    }
}