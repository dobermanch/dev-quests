//https://leetcode.com/problems/spiral-matrix-ii/

namespace LeetCode.Problems;

public sealed class SpiralOrder2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(SpiralOrder2))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(3).Result2dArray("[[1,2,3],[8,9,4],[7,6,5]]"))
          .Add(it => it.Param(4).Result2dArray("[[1,2,3,4],[12,13,14,5],[11,16,15,6],[10,9,8,7]]"))
          .Add(it => it.Param(5).Result2dArray("[[1,2,3,4,5],[16,17,18,19,6],[15,24,25,20,7],[14,23,22,21,8],[13,12,11,10,9]]"))
          .Add(it => it.Param(6).Result2dArray("[[1,2,3,4,5,6],[20,21,22,23,24,7],[19,32,33,34,25,8],[18,31,36,35,26,9],[17,30,29,28,27,10],[16,15,14,13,12,11]]"))
          .Add(it => it.Param(1).Result2dArray("[[1]]"));

    private int[][] Solution(int n)
    {
        var matrix = Enumerable.Repeat(n, n).Select(it => new int[it]).ToArray();

        var x = 0;
        var y = 0;
        var dy = 1;
        var dx = 1;
        var count = 1;
        var target = n * n;
        while(count <= target)
        {
            matrix[y][x] = count++;

            if (y == dy - 1 && x < n - dx)
            {
                x++;
            }
            else if (x == n - dx && y < n - dy)
            {
                y++;
            }
            else if (x > dx - 1)
            {
                x--;
            }
            else if (y > dy)
            {
                y--;
                if (y == dy && x == dx - 1)
                {
                    dx++;
                    dy++;
                }
            }
        }

        return matrix;
    }
}