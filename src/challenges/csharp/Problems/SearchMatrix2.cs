//https://leetcode.com/problems/search-a-2d-matrix-ii/

namespace LeetCode.Problems;

public sealed class SearchMatrix2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(SearchMatrix2))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[-1],[-1]]").Param(-2).Result(false))
          .Add(it => it.Param2dArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]").Param(5).Result(true))
          .Add(it => it.Param2dArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]").Param(20).Result(false))
          .Add(it => it.Param2dArray("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]").Param(18).Result(true));

    private bool Solution(int[][] matrix, int target)
    {
        var col = matrix[0].Length - 1;
        var row = 0;

        while (row < matrix.Length && col >= 0)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }

            if (matrix[row][col] > target)
            {
                col--;
            }
            else
            {
                row++;
            }
        }

        return false;
    }

    private bool Solution1(int[][] matrix, int target)
    {
        var n = Math.Min(matrix.Length, matrix[0].Length);
        for (int i = 0; i < n; i++)
        {
            if (matrix[i][0] <= target 
                && target <= matrix[i][^1] 
                && RowSearch(target, matrix[i]))
            {
                return true;
            }

            if (matrix[0][i] <= target 
                && target <= matrix[^1][i]
                && ColSearch(target, matrix, i))
            {
                return true;
            }
        }

        return false;
    }

    private bool RowSearch(int target, int[] row)
    {
        var start = 0;
        var end = row.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (row[mid] == target)
            {
                return true;
            }

            if (row[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return false;
    }

    private bool ColSearch(int target, int[][] matrix, int col)
    {
        var start = 0;
        var end = matrix.Length - 1;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (matrix[mid][col] == target)
            {
                return true;
            }

            if (matrix[mid][col] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return false;
    }
}