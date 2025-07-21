//https://leetcode.com/problems/single-number

namespace LeetCode.Problems;

public sealed class SingleNumber : ProblemBase
{
    [Theory]
    [ClassData(typeof(SingleNumber))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[2,2,1]").Result(1))
          .Add(it => it.ParamArray("[4,1,2,1,2]").Result(4))
          .Add(it => it.ParamArray("[1]").Result(1))
          .Add(it => it.ParamArray("[-4,1,-4,1,-1]").Result(-1));

    private int Solution(int[] nums)
    {
        var mask = 0;
        foreach (var num in nums)
        {
            mask ^= num;
        }

        return mask;
    }
}