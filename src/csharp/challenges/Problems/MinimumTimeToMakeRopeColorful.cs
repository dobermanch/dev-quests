// https://leetcode.com/problems/minimum-time-to-make-rope-colorful

namespace LeetCode.Problems;

public sealed class MinCost : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinCost))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("bbbaaa").ParamArray("[4,9,3,8,8,9]").Result(23))
          .Add(it => it.Param("aaabbbabbbb").ParamArray("[3,5,10,7,5,3,5,5,4,8,1]").Result(26))
          .Add(it => it.Param("abaac").ParamArray("[1,2,3,4,5]").Result(3))
          .Add(it => it.Param("abc").ParamArray("[1,2,3]").Result(0))
          .Add(it => it.Param("aabaa").ParamArray("[1,2,3,4,1]").Result(2));

    private int Solution(string colors, int[] neededTime)
    {
        var result = 0;
        var maxCost = neededTime[0];
        for (int i = 1; i < colors.Length; i++)
        {
            if (colors[i] == colors[i - 1])
            {
                result += Math.Min(neededTime[i], maxCost);
                maxCost = Math.Max(neededTime[i], maxCost);
            }
            else
            {
                maxCost = neededTime[i];
            }
        }

        return result;
    }
}