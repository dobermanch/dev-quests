//https://leetcode.com/problems/find-the-middle-index-in-array/

namespace LeetCode.Problems;

public sealed class FindMiddleIndex : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMiddleIndex))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,-1,8,4]").Result(3))
            .Add(it => it.ParamArray("[1,-1,4]").Result(2))
            .Add(it => it.ParamArray("[2,5]").Result(-1))
            .Add(it => it.ParamArray("[1, 7, 3, 6, 5, 6]").Result(3))
            .Add(it => it.ParamArray("[1,2,3]").Result(-1))
            .Add(it => it.ParamArray("[-1,-1,-1,0,1,1]").Result(0))
            .Add(it => it.ParamArray("[-1,-1,-1,-1,-1,0]").Result(2));

    private int Solution(int[] nums)
    {
        var leftSum = 0;
        var rightSum = 0;
        var index = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        while (leftSum != rightSum && index < nums.Length - 1)
        {
            leftSum += nums[index];
            rightSum -= nums[index + 1];
            index++;
        }

        return leftSum != rightSum ? -1 : index;
    }
}