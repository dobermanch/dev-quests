//https://leetcode.com/problems/triangle/

namespace LeetCode.Problems;

public sealed class MinimumTotal : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinimumTotal))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[2],[3,4],[6,5,7],[4,1,8,3]]").Result(11))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,1,8,3]]").Result(11))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[3,4,3,2]]").Result(12))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[3,4,3,2],[3,1,4,5,2]]").Result(14))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,2,4,2],[3,2,4,5,1]]").Result(13))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,4],[4,3,4,2],[3,1,4,5,3]]").Result(14))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,6],[6,4,7,3],[3,1,4,5,3]]").Result(15))
          .Add(it => it.Param2dArray("[[2],[3,4],[6,5,6],[6,3,7,1],[3,1,4,2,4]]").Result(14))
          .Add(it => it.Param2dArray("[[-10]]").Result(-10));

    private int Solution(IList<IList<int>> triangle)
    {
        for (var i = triangle.Count - 2; i >= 0; i--)
        {
            for (var j = 0; j < triangle[i].Count; j++)
            {
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }

        return triangle[0][0];
    }
}