//https://leetcode.com/problems/triangle/

namespace LeetCode.Problems;

public sealed class MinimumTotal : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinimumTotal))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.Param2dArray("[[2],[3,4],[6,5,7],[4,1,8,3]]").Result(11))
          .Add(true, it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,1,8,3]]").Result(11))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[3,4,3,2]]").Result(12))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[3,4,3,2],[3,1,4,5,2]]").Result(14))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,2,4,2],[3,2,4,5,1]]").Result(13))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,3,4,2],[3,1,4,5,3]]").Result(14))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,6],[6,4,7,3],[3,1,4,5,3]]").Result(15))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,6],[6,3,7,1],[3,1,4,2,4]]").Result(14))
          .Add(it => it.Param2dArray("[[-10]]").Result(-10));

    private int Solution(IList<IList<int>> triangle)
    {
        var count = 0;
        //var index = 0;
        //for (var i = 0; i < triangle.Count; i++)
        //{
        //    if (triangle[i].Count > index + 1)
        //    {
        //        if (triangle[i][index + 1] < triangle[i][index])
        //        {
        //            index++;
        //        }
        //    }

        //    count += triangle[i][index];
        //}

        var accum = 0;
        var nums = new[] { 1, 3, 1, -1, 3 };
        for (int i = 0; i < nums.Length; i++)
        {
            //if ((accum & nums[i]) == nums[i])
            //{
                accum ^= nums[i];
            //}
            //else
            //{
            //    accum |= nums[i];
            //}
        }

        return count;
    }
}