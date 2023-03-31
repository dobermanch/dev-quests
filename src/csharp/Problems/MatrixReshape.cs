//https://leetcode.com/problems/reshape-the-matrix/

namespace LeetCode.Problems;

public sealed class MatrixReshape : ProblemBase
{
    [Theory]
    [ClassData(typeof(MatrixReshape))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,3,4],[3,4,5,6],[3,4,5,6],[3,4,5,6]]").Param(2).Param(8).Result2dArray("[[1,2,3,4,3,4,5,6],[3,4,5,6,3,4,5,6]]"))
          .Add(it => it.Param2dArray("[[1,2],[3,4]]").Param(1).Param(4).Result2dArray("[[1,2,3,4]]"))
          .Add(it => it.Param2dArray("[[1,2],[3,4]]").Param(2).Param(4).Result2dArray("[[1,2],[3,4]]"));

    private int[][] Solution(int[][] mat, int r, int c)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;

        if (rows * cols != r * c)
        {
            return mat;
        }

        var result = Enumerable.Range(0, r).Select(it => new int[c]).ToArray();

        for (var y1 = 0; y1 < rows; y1++)
        {
            for (var x1 = 0; x1 < cols; x1++)
            {
                var y2 = (y1 * cols + x1) / c;
                var x2 = (y1 * cols + x1) % c;

                result[y2][x2] = mat[y1][x1];
            }
        }

        return result;
    }
}