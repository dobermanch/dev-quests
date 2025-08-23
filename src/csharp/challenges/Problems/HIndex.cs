//https://leetcode.com/problems/h-index

namespace LeetCode.Problems;

public sealed class HIndex : ProblemBase
{
    [Theory]
    [ClassData(typeof(HIndex))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[3,0,6,1,5]").Result(3))
          .Add(it => it.ParamArray("[1,3,1]").Result(1))
          .Add(it => it.ParamArray("[3,5,6,1,2,7,4]").Result(4))
          .Add(it => it.ParamArray("[100]").Result(1));

    private int Solution(int[] citations)
    {
        Array.Sort(citations);

        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] < citations.Length - i)
            {
                continue;
            }

            for (var hIndex = citations[i]; hIndex >= 0; hIndex--)
            {
                if (hIndex <= citations.Length - i)
                {
                    return hIndex;
                }
            }
        }

        return 0;
    }
}