//https://leetcode.com/problems/counting-bits/

namespace LeetCode.Problems;

public sealed class CountBits : ProblemBase
{
    [Theory]
    [ClassData(typeof(CountBits))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(2).ResultArray("[0,1,1]"))
          .Add(it => it.Param(5).ResultArray("[0,1,1,2,1,2]"))
          .Add(it => it.Param(20).ResultArray("[0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4,1,2,2,3,2]"));

    private int[] Solution(int n)
    {
        var result = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            result[i] = result[i & i - 1] + 1;
        }

        return result;
    }
}