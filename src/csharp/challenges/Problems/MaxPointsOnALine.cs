
// https://leetcode.com/problems/max-points-on-a-line

namespace LeetCode.Problems;

public sealed class MaxPointsOnALine : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxPointsOnALine))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]").Result(4))
          .Add(it => it.Param2dArray("[[1,1],[2,2],[3,3]]").Result(3))
        ;

    private int Solution(int[][] points)
    {
        if (points.Length <= 2)
        {
            return points.Length;
        }

        var maxPoints = 1;
        for (var i = 0; i < points.Length; i++)
        {
            var slopes = new Dictionary<float, int>();
            for (var j = i + 1; j < points.Length; j++)
            {
                var (x1, y1) = (points[i][0], points[i][1]);
                var (x2, y2) = (points[j][0], points[j][1]);

                float slope = int.MaxValue;
                if (x1 - x2 != 0)
                {
                    slope = (y1 - y2) / (float)(x1 - x2);
                }

                if (!slopes.TryAdd(slope, 1))
                {
                    slopes[slope] += 1;
                }

                maxPoints = Math.Max(slopes[slope], maxPoints);
            }
        }

        return maxPoints + 1;
    }
}
