//https://leetcode.com/problems/image-smoother

namespace LeetCode.Problems;

public sealed class ImageSmoother : ProblemBase
{
    [Theory]
    [ClassData(typeof(ImageSmoother))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[100,200,100],[200,50,200],[100,200,100]]").Result2dArray("[[137,141,137],[141,138,141],[137,141,137]]"))
          .Add(it => it.Param2dArray("[[1,1,1],[1,0,1],[1,1,1]]").Result2dArray("[[0,0,0],[0,0,0],[0,0,0]]"));

    private int[][] Solution(int[][] img)
    {
        int[,] directions = { 
            { -1, -1 }, { -1, 0 }, { -1, 1 }, 
            {  0, -1 }, {  0, 0 }, {  0, 1 }, 
            {  1, -1 }, {  1, 0 }, {  1, 1 } 
        };

        var count = directions.GetLength(0);
        var rows = img.Length;
        var cols = img[0].Length;
        var result = new int[rows][];

        for (var row = 0; row < rows; row++)
        {
            result[row] = new int[cols];
            for (var col = 0; col < cols; col++)
            {
                var neighbors = 0;

                for (var i = 0; i < count; i++)
                {
                    var y = row + directions[i, 0];
                    var x = col + directions[i, 1];

                    if (y >= 0 && y < rows
                        && x >= 0 && x < cols)
                    {
                        result[row][col] += img[y][x];
                        neighbors++;
                    }
                }

                result[row][col] /= neighbors;
            }
        }

        return result;
    }
}