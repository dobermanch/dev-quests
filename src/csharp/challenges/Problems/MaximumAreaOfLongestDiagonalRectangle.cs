
// https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle

namespace LeetCode.Problems;

public sealed class MaximumAreaOfLongestDiagonalRectangle : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaximumAreaOfLongestDiagonalRectangle))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[9, 3], [8, 6]]").Result(48))
          .Add(it => it.Param2dArray("[[3, 4], [4, 3]]").Result(12))
        ;

    private int Solution1(int[][] dimensions)
    {
        var maxDiagonal = .0;
        var maxArea = 0;

        foreach (var row in dimensions)
        {
            var diagonal = Math.Sqrt(Math.Pow(row[0], 2) + Math.Pow(row[1], 2));
            var area = row[0] * row[1];

            if (diagonal > maxDiagonal)
            {
                maxDiagonal = diagonal;
                maxArea = area;
            }
            else if (Math.Abs(diagonal - maxDiagonal) < 0.001)
            {
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    private int Solution2(int[][] dimensions)
    {
        var diagonals = new PriorityQueue<int, double>();

        foreach (var row in dimensions)
        {
            var diag = Math.Sqrt(Math.Pow(row[0], 2) + Math.Pow(row[1], 2));
            diagonals.Enqueue(row[0] * row[1], -diag);
        }

        diagonals.TryDequeue(out var area, out var diagonal);
        while (diagonals.Count > 0)
        {
            diagonals.TryDequeue(out var nextArea, out var nextDiagonal);
            if (Math.Abs(diagonal - nextDiagonal) < 0.001)
            {
                area = Math.Max(area, nextArea);
            }
            else
            {
                break;
            }
        }

        return area;
    }
}
