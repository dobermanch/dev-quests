//https://leetcode.com/problems/house-robber/

namespace LeetCode.Problems;

public sealed class Rob : ProblemBase
{
    [Theory]
    [ClassData(typeof(Rob))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,12,1,3,15,2,4,5,7]").Result(40))
          .Add(it => it.ParamArray("[1,2,3,1,12,3,5,2,4,5,7]").Result(32))
          .Add(it => it.ParamArray("[1,2,3,1]").Result(4))
          .Add(it => it.ParamArray("[2,7,9,3,1]").Result(12))
          .Add(it => it.ParamArray("[2,1,1,2]").Result(4))
          .Add(it => it.ParamArray("[0]").Result(0));

    private int Solution(int[] nums)
    {
        var rob1 = 0;
        var rob2 = 0;
        foreach (var num in nums)
        {
            var temp = rob2;
            rob2 = Math.Max(rob1 + num, rob2);
            rob1 = temp;
        }

        return rob2;
    }
}