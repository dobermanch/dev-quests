//https://leetcode.com/problems/flood-fill/description

namespace LeetCode.Problems;

public sealed class FloodFill : ProblemBase
{
    [Theory]
    [ClassData(typeof(FloodFill))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1,1],[1,1,0],[1,0,1]]").Param(1).Param(1).Param(2).Result2dArray("[[2,2,2],[2,2,0],[2,0,1]]"))
            .Add(it => it.Param2dArray("[[0,0,0],[0,0,0]]").Param(0).Param(0).Param(0).Result2dArray("[[0,0,0],[0,0,0]]"));

    private int[][] Solution(int[][] image, int sr, int sc, int color)
    {
        if (image[sr][sc] != color)
        {
            Fill(image, sc, sr, image[sr][sc], color);
        }

        return image;
    }

    private static void Fill(int[][] image, int x, int y, int originalColor, int replaceColor)
    {
        if (y < 0 || y >= image.Length
                  || x < 0 || x >= image[y].Length
                  || image[y][x] != originalColor)
        {
            return;
        }

        image[y][x] = replaceColor;

        Fill(image, x - 1, y, originalColor, replaceColor);
        Fill(image, x + 1, y, originalColor, replaceColor);
        Fill(image, x, y + 1, originalColor, replaceColor);
        Fill(image, x, y - 1, originalColor, replaceColor);
    }
}