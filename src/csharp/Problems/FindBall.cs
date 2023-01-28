//https://leetcode.com/problems/where-will-the-ball-fall/
public class FindBall {

    public static void Run(){
        var d = Run(new int[][] { new [] { 1,1,1,-1,-1 }, new [] {1,1,1,-1,-1 }, new [] { -1,-1,-1,1,1 }, new [] { 1,1,1,1,-1 }, new [] { -1,-1,-1,-1,-1 }}); //[1,-1,-1,-1,-1]
    }

    private static int[] Run(int[][] grid)
    {
        var width = grid[0].Length;
        var balls = Enumerable.Range(0, grid[0].Length).ToArray();

        for(var y = 0; y < grid.Length; y++)
        {
            for(var b = 0; b < width; b++)
            {
                if (balls[b] == -1)
                {
                    continue;
                }

                var x = balls[b];
                if (grid[y][x] == 1)
                {
                    if (x + 1 == width ||  grid[y][x + 1] == -1)
                    {
                        balls[b] = -1;
                    }
                    else
                    {
                        balls[b] = x + 1;
                    }
                }
                else if (grid[y][x] == -1)
                {
                    if (x - 1 < 0 || grid[y][x - 1] == 1)
                    {
                        balls[b] = -1;
                    }
                    else
                    {
                        balls[b] = x - 1;
                    }
                }
            }
        }

        return balls;
    }
}