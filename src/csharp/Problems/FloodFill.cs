//https://leetcode.com/problems/flood-fill/description

namespace LeetCode.Problems;

public sealed class FloodFill : ProblemBase
{
    public static void Run()
    {
        //var d = Run(new int[][] { new int[] {1,1,1}, new int[] {1,1,0}, new int[] {1,0,1} }, 1, 1, 2);
        var d = Run(new int[][] { new int[] { 0, 0, 0 }, new int[] { 1, 0, 0 } }, 1, 0, 2);
    }

    private static int[][] Run(int[][] image, int sr, int sc, int color)
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