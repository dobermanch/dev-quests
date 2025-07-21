//https://leetcode.com/problems/rotate-image

namespace LeetCode.Problems;

public sealed class RotateImage : ProblemBase
{
    [Theory]
    [ClassData(typeof(RotateImage))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,3],[4,5,6],[7,8,9]]").Result2dArray("[[7,4,1],[8,5,2],[9,6,3]]"))
          .Add(it => it.Param2dArray("[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]").Result2dArray("[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]"))
          .Add(it => it.Param2dArray("[[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]").Result2dArray("[[21,16,11,6,1],[22,17,12,7,2],[23,18,13,8,3],[24,19,14,9,4],[25,20,15,10,5]]"))
          .Add(it => it.Param2dArray("[[1,2,3,4,5,6],[7,8,9,10,11,12],[13,14,15,16,17,18],[19,20,21,22,23,24],[25,26,27,28,29,30],[31,32,33,34,35,36]]").Result2dArray("[[31,25,19,13,7,1],[32,26,20,14,8,2],[33,27,21,15,9,3],[34,28,22,16,10,4],[35,29,23,17,11,5],[36,30,24,18,12,6]]"));

    private int[][] Solution(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var xL = 0;
        var xR = cols - 1;
        var yT = 0;
        var yB = rows - 1;

        while (xL < xR)
        {
            var x = xL;
            var y = yT;

            while (x < xR)
            {
                var temp = matrix[y][x];
                var x1 = x;
                var y1 = y;

                for (int i = 0; i < 4; i++)
                {
                    if (y1 == yT)
                    {
                        y1 = x1;
                        x1 = xR;
                    }
                    else if (y1 == yB)
                    {
                        y1 = x1;
                        x1 = xL;
                    }
                    else if (x1 == xR)
                    {
                        x1 = (cols - 1) - y1;
                        y1 = yB;
                    }
                    else if (x1 == xL)
                    {
                        x1 = cols - 1 - y1;
                        y1 = yT;
                    }

                    (matrix[y1][x1], temp) = (temp, matrix[y1][x1]);
                }

                x++;
            }

            xL++;
            xR--;
            yT++;
            yB--;
        }

        return matrix;
    }
}