//https://leetcode.com/problems/longest-consecutive-sequence/

namespace LeetCode.Problems;

public sealed class LongestConsecutive : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestConsecutive))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,0,-1]").Result(3))
          .Add(it => it.ParamArray("[100,4,200,1,3,2]").Result(4))
          .Add(it => it.ParamArray("[0,3,7,2,5,8,4,6,0,1]").Result(9));

    private int Solution(int[] nums)
    {
        var map = nums.ToHashSet();
        var max = 0;
        foreach (var num in nums)
        {
            if (map.Contains(num - 1))
            {
                continue;
            }

            var count = 1;
            while (map.Contains(num + count))
            {
                count++;
            }

            max = Math.Max(max, count);
        }

        return max;
    }
}