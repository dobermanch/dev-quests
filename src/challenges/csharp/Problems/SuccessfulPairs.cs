//https://leetcode.com/problems/successful-pairs-of-spells-and-potions

namespace LeetCode.Problems;

public sealed class SuccessfulPairs : ProblemBase
{
    [Theory]
    [ClassData(typeof(SuccessfulPairs))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[56029,39759,11542,85170,95989,20920,68729]").ParamArray("[68460,91879,36597,48406,45552,29774,99922,50056,76873,96948,97065,88424,24302]").Param(1651505078).ResultArray("[12,10,0,13,13,5,13]"))
          .Add(it => it.ParamArray("[5,1,3]").ParamArray("[1,2,3,4,5]").Param(7).ResultArray("[4,0,3]"))
          .Add(it => it.ParamArray("[3,1,2]").ParamArray("[8,5,8]").Param(16).ResultArray("[2,0,2]"));

    private int[] Solution(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        var result = new int[spells.Length];
        for (var i = 0; i < spells.Length; i++)
        {
            var left = 0;
            var right = potions.Length - 1;
            var spell = (long)spells[i];
            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (spell * potions[mid] >= success)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            result[i] = potions.Length - left;
        }

        return result;
    }
}