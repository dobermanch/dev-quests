//https://leetcode.com/problems/set-matrix-zeroes/

namespace LeetCode.Problems;

public sealed class SetZeroes : ProblemBase
{
    [Theory]
    [ClassData(typeof(SetZeroes))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(true, it => it.Param2dArray("[[1,1,1],[1,0,1],[1,1,1]]").Result2dArray("[[1,0,1],[0,0,0],[1,0,1]]"))
          .Add(it => it.Param2dArray("[[-4,-22,6,-7,0],[-8,6,-8,-6,0],[2,2,-9,-6,-10]]").Result2dArray("[[0,0,0,0,0],[0,0,0,0,0],[2,2,-9,-6,0]]"))
          .Add(it => it.Param2dArray("[[1,2,3,4],[5,0,7,8],[0,10,11,12],[13,14,15,0]]").Result2dArray("[[0,0,3,0],[0,0,0,0],[0,0,0,0],[0,0,0,0]]"))
          .Add(it => it.Param2dArray("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]").Result2dArray("[[0,0,0,0],[0,4,5,0],[0,3,1,0]]"))
          .Add(it => it.Param2dArray("[[0,1,2,0,5],[3,4,5,2,8],[1,0,1,5,9],[5,7,1,5,9]]").Result2dArray("[[0,0,0,0,0],[0,0,5,0,8],[0,0,0,0,0],[0,0,1,0,9]]"))
        ;

    private int[][] Solution(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var x0 = false;
        for (int y = 0; y < rows; y++)
        {
            if (matrix[y][0] == 0)
            {
                x0 = true;
            }

            for (int x = 1; x < cols; x++)
            {
                if (matrix[y][x] == 0)
                {
                    matrix[0][x] = 0;
                    matrix[y][0] = 0;
                }
            }
        }

        for (int y = rows - 1; y >= 0; y--)
        {
            for (int x = cols - 1; x >= 1; x--)
            {
                if (matrix[0][x] == 0 || matrix[y][0] == 0)
                {
                    matrix[y][x] = 0;
                }
            }

            if (x0)
            {
                matrix[y][0] = 0;
            }
        }

        return matrix;
    }
}