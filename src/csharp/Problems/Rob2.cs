//https://leetcode.com/problems/house-robber-ii/

namespace LeetCode.Problems;

public sealed class Rob2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(Rob2))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[2,3,2]").Result(3))
          .Add(it => it.ParamArray("[1,2,3,1]").Result(4))
          .Add(it => it.ParamArray("[1,2,3]").Result(3))
          .Add(it => it.ParamArray("[2,7,9,3,1]").Result(11))
          .Add(it => it.ParamArray("[2,7,9,3,12]").Result(21))
          .Add(it => it.ParamArray("[2,7,9,3,1,12]").Result(22))
          .Add(it => it.ParamArray("[2,7,4,5,3,5,6,8,5,9,3,1,12]").Result(46))
          .Add(it => it.ParamArray("[1]").Result(1));

    private int Solution(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        int RobHouses(int from, int to)
        {
            var rob1 = 0;
            var rob2 = 0;
            for (var i = from; i < to; i++)
            {
                var temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }

        return Math.Max(RobHouses(0, nums.Length - 1), RobHouses(1, nums.Length));
    }
}