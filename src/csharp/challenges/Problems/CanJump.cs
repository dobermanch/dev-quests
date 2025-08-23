//https://leetcode.com/problems/jump-game/

namespace LeetCode.Problems;

public sealed class CanJump : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanJump))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,1,1,4]").Result(true))
          .Add(it => it.ParamArray("[1,1,2,2,0,1,1]").Result(true))
          .Add(it => it.ParamArray("[5,9,3,2,1,0,2,3,3,1,0,0]").Result(true))
          .Add(it => it.ParamArray("[2,0]").Result(true))
          .Add(it => it.ParamArray("[1,0,2,3]").Result(false))
          .Add(it => it.ParamArray("[2,3,0,1,4]").Result(true))
          .Add(it => it.ParamArray("[2,5,0,0]").Result(true))
          .Add(it => it.ParamArray("[3,1,0,2,4]").Result(true))
          .Add(it => it.ParamArray("[3,2,1,0,4]").Result(false))
        ;

    private bool Solution(int[] nums)
    {
        var jumpTo = nums.Length - 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= jumpTo)
            {
                jumpTo = i;
            }
        }

        return jumpTo == 0;
    }
}