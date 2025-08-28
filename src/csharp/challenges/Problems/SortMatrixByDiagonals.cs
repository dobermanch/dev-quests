
// https://leetcode.com/problems/sort-matrix-by-diagonals

namespace LeetCode.Problems;

public sealed class SortMatrixByDiagonals : ProblemBase
{
    [Theory]
    [ClassData(typeof(SortMatrixByDiagonals))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,7,3,5],[9,8,2,2],[4,5,6,8],[4,2,8,7]]").Result2dArray("[[8,2,2,5],[9,7,7,3],[4,8,6,8],[4,2,5,1]]"))
          .Add(it => it.Param2dArray("[[1,7,3],[9,8,2],[4,5,6]]").Result2dArray("[[8,2,3],[9,6,7],[4,5,1]]"))
          .Add(it => it.Param2dArray("[[0,1],[1,2]]").Result2dArray("[[2,1],[1,0]]"))
        ;

    private int[][] Solution(int[][] grid)
    {
        var n = grid.Length;

        var diagonals = Enumerable.Range(0, 2 * n - 1).Select(it => new List<int>()).ToArray();

        for (var row = 0; row < n; row++)
        {
            for (var col = 0; col < n; col++)
            {
                var diagonal = n + col - row - 1;
                diagonals[diagonal].Add(grid[row][col]);
            }
        }

        for (var i = 0; i < diagonals.Length; i++)
        {
            if (i < n)
            {
                diagonals[i].Sort((a, b) => b.CompareTo(a));
            }
            else
            {
                diagonals[i].Sort();
            }

            var len = diagonals[i].Count;
            for (var j = 0; j < len; j++)
            {
                var row = n - len + j;
                var col = j;
                if (i >= n)
                {
                    row = j;
                    col = n - len + j;
                }

                grid[row][col] = diagonals[i][j];
            }
        }

        return grid;
    }
}
