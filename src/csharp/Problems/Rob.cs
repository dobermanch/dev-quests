//https://leetcode.com/problems/house-robber/

namespace LeetCode.Problems;

public sealed class Rob : ProblemBase
{
    [Theory]
    [ClassData(typeof(Rob))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3,12,1,3,15,2,4,5,7]").Result(40))
          .Add(it => it.ParamArray("[1,2,3,1,12,3,5,2,4,5,7]").Result(32))
          .Add(it => it.ParamArray("[1,2,3,1]").Result(4))
          .Add(it => it.ParamArray("[2,7,9,3,1]").Result(12))
          .Add(it => it.ParamArray("[2,1,1,2]").Result(4))
          .Add(it => it.ParamArray("[0]").Result(0));

    private int Solution(int[] nums)
    {
        var t0 = 0;
        var t1 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var temp = t1;
            t1 = Math.Max(t0 + nums[i], t1);
            t0 = temp;
        }

        return t1;
    }
}