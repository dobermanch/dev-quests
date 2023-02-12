//https://leetcode.com/problems/3sum-closest/

namespace LeetCode.Problems;

public sealed class ThreeSumClosest : ProblemBase
{
    [Theory]
    [ClassData(typeof(ThreeSumClosest))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[-1,2,1,-4]").Param(1).Result(2))
          .Add(it => it.ParamArray("[1,1,1,0]").Param(-100).Result(2))
          .Add(it => it.ParamArray("[4,0,5,-5,3,3,0,-4,-5]").Param(-2).Result(-2))
          .Add(it => it.ParamArray("[4,0,5,3,3,0,-4]").Param(-2).Result(-1))
          .Add(it => it.ParamArray("[0,0,0]").Param(1).Result(0));

    private int Solution(int[] num, int target)
    {
        return 0;
    }
}