//https://leetcode.com/problems/summary-ranges

namespace LeetCode.Problems;

public sealed class SummaryRanges : ProblemBase
{
    [Theory]
    [ClassData(typeof(SummaryRanges))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[0,1,2,4,5,7]").ResultArray<string>("""["0->2","4->5","7"]"""))
          .Add(it => it.ParamArray("[0,2,3,4,6,8,9]").ResultArray<string>("""["0","2->4","6","8->9"]"""))
          .Add(it => it.ParamArray("[0]").ResultArray<string>("""["0"]"""));

    private IList<string> Solution(int[] nums)
    {
        var result = new List<string>();
        var startAt = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i == nums.Length - 1 || nums[i] + 1 < nums[i + 1] )
            {
                result.Add(
                    i == startAt
                        ? $"{nums[startAt]}" 
                        : $"{nums[startAt]}->{nums[i]}"
                );

                startAt = i + 1;
            }
        }

        return result;
    }
}