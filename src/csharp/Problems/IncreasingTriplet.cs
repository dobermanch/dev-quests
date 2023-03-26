//https://leetcode.com/problems/increasing-triplet-subsequence/

namespace LeetCode.Problems;

public sealed class IncreasingTriplet : ProblemBase
{
    [Theory]
    [ClassData(typeof(IncreasingTriplet))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.ParamArray("[20,100,10,12,5,13]").Result(true))
          .Add(true, it => it.ParamArray("[1,2,1,3]").Result(true))
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
        var result = 1;
        int? min = null;
        for (var i = 1; i < nums.Length; i++)
        {
            //if (min < nums[i + 1])
            //{
            //    return true;
            //}

            if (min < nums[i])
            {
                result++;
                if (result == 3)
                {
                    return true;
                }
            }
            else
            {
                //min = Math.Min(min ?? int.MaxValue, nums[i]);
                result = 1;
            }

            min = Math.Min(min ?? int.MaxValue, nums[i]);
        }

        return false;
    }
}