// https://leetcode.com/problems/transpose-matrix

namespace LeetCode.Problems;

public sealed class Transpose : ProblemBase
{
    [Theory]
    [ClassData(typeof(Transpose))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,3],[4,5,6],[7,8,9]]").Result2dArray("[[1,4,7],[2,5,8],[3,6,9]]"))
          .Add(it => it.Param2dArray("[[1,2,3],[4,5,6]]").Result2dArray("[[1,4],[2,5],[3,6]]"));

    private int[][] Solution(int[][] matrix)
    {
        var result = new int[matrix[0].Length][];

        for (var col = 0; col < matrix[0].Length; col++)
        {
            result[col] = new int[matrix.Length];
            for (var row = 0; row < matrix.Length; row++)
            {
                result[col][row] = matrix[row][col];
            }
        }

        return result;
    }
}