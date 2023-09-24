//https://leetcode.com/problems/kids-with-the-greatest-number-of-candies

namespace LeetCode.Problems;

public sealed class KidsWithCandies : ProblemBase
{
    [Theory]
    [ClassData(typeof(KidsWithCandies))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,5,1,3]").Param(3).ResultArray<bool>("[true,true,true,false,true]"))
          .Add(it => it.ParamArray("[4,2,1,1,2]").Param(1).ResultArray<bool>("[true,false,false,false,false]"))
          .Add(it => it.ParamArray("[12,1,12]").Param(10).ResultArray<bool>("[true,false,true]"));

    private IList<bool> Solution(int[] candies, int extraCandies)
    {
        var maxCandies = candies.Max();
        var result = new bool[candies.Length];

        for (var i = 0; i < candies.Length; i++)
        {
            result[i] = candies[i] + extraCandies >= maxCandies;
        }

        return result;
    }
}