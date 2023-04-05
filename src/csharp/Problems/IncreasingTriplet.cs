//https://leetcode.com/problems/increasing-triplet-subsequence/

namespace LeetCode.Problems;

public sealed class IncreasingTriplet : ProblemBase
{
    [Theory]
    [ClassData(typeof(IncreasingTriplet))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[20,100,10,12,5,13]").Result(true))
          .Add(it => it.ParamArray("[1,2,1,3]").Result(true))
          .Add(it => it.ParamArray("[5,1,6]").Result(false))
          .Add(it => it.ParamArray("[0,4,2,1,0,-1,-3]").Result(false))
          .Add(it => it.ParamArray("[1,5,0,4,1,3]").Result(true))
          .Add(it => it.ParamArray("[20,100,10,16,15,12,3,13]").Result(true))
          .Add(it => it.ParamArray("[20,21,10,16,15,9,3,22]").Result(true))
          .Add(it => it.ParamArray("[20,21,10,16,15,12,3,13]").Result(true))
          .Add(it => it.ParamArray("[2,4,-2,-3]").Result(false))
          .Add(it => it.ParamArray("[1,2,3,4,5]").Result(true))
          .Add(it => it.ParamArray("[5,4,3,2,1]").Result(false))
          .Add(it => it.ParamArray("[2,1,5,0,4,6]").Result(true));

    private bool Solution(int[] nums)
    {
        var n1 = int.MaxValue;
        var n2 = int.MaxValue;
        foreach (var num in nums)
        {
            if (num > n2)
            {
                return true;
            }

            if (num <= n1)
            {
                n1 = num;
            }
            else if (num < n2)
            {
                n2 = num;
            }
        }

        return false;
    }
}