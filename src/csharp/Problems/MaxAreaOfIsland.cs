//https://leetcode.com/problems/max-area-of-island/

namespace LeetCode.Problems;

public sealed class MaxAreaOfIsland : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaxAreaOfIsland))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]").Result(6))
          .Add(it => it.Param2dArray("[[0,0,0,0,0,0,0,0]]").Result(0))
          .Add(it => it.Param2dArray("[[1,1,0,0,0],[1,1,0,0,0],[0,0,0,1,1],[0,0,0,1,1]]").Result(4));

    private int Solution(int[][] grid)
    {
        int[,] directions = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
        var height = grid.Length;
        var width = grid[0].Length;

        var visited = new bool[height, width];

        var maxSize = 0;
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (visited[y, x] || grid[y][x] == 0)
                {
                    visited[y, x] = true;
                    continue;
                }

                var size = 0;
                var queue = new Queue<(int x, int y)>();
                queue.Enqueue((x, y));
                while (queue.Any())
                {
                    var current = queue.Dequeue();

                    visited[current.y, current.x] = true;
                    size++;

                    for (var i = 0; i < directions.GetLength(0); i++)
                    {
                        var xd = current.x + directions[i, 0];
                        var yd = current.y + directions[i, 1];

                        if (yd >= 0 && yd < height 
                            && xd >= 0 && xd < width
                            && !visited[yd, xd]
                            && grid[yd][xd] == 1)
                        {
                            visited[yd, xd] = true;
                            queue.Enqueue((xd, yd));
                        }
                    }
                }

                maxSize = Math.Max(maxSize, size);
            }
        }

        return maxSize;
    }
}