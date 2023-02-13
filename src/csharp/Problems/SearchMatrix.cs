//https://leetcode.com/problems/search-a-2d-matrix/

namespace LeetCode.Problems;

public sealed class SearchMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(SearchMatrix))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray(new[]{1,3,5,7}, new[]{10,11,16,20}, new[]{23,30,34,60}).Param(3).Result(true))
          .Add(it => it.ParamArray(new[]{1,3,5,7}, new[]{10,11,16,20}, new[]{23,30,34,60}).Param(13).Result(false))
          .Add(it => it.ParamArray(new[]{1,3,5,7}, new[]{10,11,16,20}, new[]{23,30,34,60}, new[]{71,73,74,80}).Param(30).Result(true))
          .Add(it => it.ParamArray<int[]>(new []{ 1 }).Param(1).Result(true));

    private bool Solution(int[][] matrix, int target)
    {
        var start = 0;
        var end = matrix.Length - 1;
        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (matrix[mid][0] <= target && target <= matrix[mid][^1])
            {
                return RowSearch(target, matrix[mid]);
            }

            if (matrix[mid][^1] > target)
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
}