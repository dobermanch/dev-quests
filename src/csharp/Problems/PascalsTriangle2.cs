//https://leetcode.com/problems/pascals-triangle-ii/

namespace LeetCode.Problems;

public sealed class PascalsTriangle2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(PascalsTriangle2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(1).ResultArray("[1,1]"))
          .Add(it => it.Param(2).ResultArray("[1,2,1]"))
          .Add(it => it.Param(3).ResultArray("[1,3,3,1]"))
          .Add(it => it.Param(4).ResultArray("[1,4,6,4,1]"))
          .Add(it => it.Param(5).ResultArray("[1,5,10,10,5,1]"));

    private IList<int> Solution(int rowIndex)
    {
        var result = Enumerable.Repeat(1, rowIndex + 1).ToArray();

        for (var i = 2; i < result.Length; i++)
        {
            var prev = result[0];
            for (var j = 1; j < i; j++)
            {
                var temp = result[j];
                result[j] = prev + result[j];
                prev = temp;
            }
        }

        return result;
    }
}