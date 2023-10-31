//https://leetcode.com/problems/missing-number/

namespace LeetCode.Problems;

public sealed class MissingNumber : ProblemBase
{
    [Theory]
    [ClassData(typeof(MissingNumber))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[3,0,1]").Result(2))
          .Add(it => it.ParamArray("[0,1]").Result(2))
          .Add(it => it.ParamArray("[9,6,4,2,3,5,7,0,1]").Result(8))
          .Add(it => it.ParamArray("[9,6,4,2,3,5,7,0,1,10,11,12]").Result(8))
          .Add(it => it.ParamArray("[9,6,4,2,3,5,7,0,1,10,11,12,13]").Result(8));

    private int Solution(int[] nums)
    {
        var result = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        {
            result += i - nums[i];
        }

        return result;
    }

    private int Solution1(int[] nums)
    {
        var n = nums.Length;
        var result = n * (n + 1) / 2;
        foreach (var num in nums)
        {
            result -= num;
        }

        return result;
    }
}