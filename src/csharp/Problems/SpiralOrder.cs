//https://leetcode.com/problems/spiral-matrix/

namespace LeetCode.Problems;

public sealed class SpiralOrder : ProblemBase
{
    [Theory]
    [ClassData(typeof(SpiralOrder))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,3],[4,5,6],[7,8,9]]").ResultArray("[1,2,3,6,9,8,7,4,5]"))
          .Add(it => it.Param2dArray("[[1,2,3,4],[5,6,7,8],[9,10,11,12]]").ResultArray("[1,2,3,4,8,12,11,10,9,5,6,7]"));

    private IList<int> Solution(int[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;
        var lenght = width * height;

        var result = new List<int>(lenght);
        var x = 0;
        var y = 0;
        var dy = 1;
        var dx = 1;

        while (result.Count < lenght)
        {
            result.Add(matrix[y][x]);

            if (y == dy - 1 && x < width - dx)
            {
                x++;
            }
            else if (x == width - dx && y < height - dy)
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

        return result;
    }
}