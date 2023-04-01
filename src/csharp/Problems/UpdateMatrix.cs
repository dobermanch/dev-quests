//https://leetcode.com/problems/01-matrix/

namespace LeetCode.Problems;

public sealed class UpdateMatrix : ProblemBase
{
    [Theory]
    [ClassData(typeof(UpdateMatrix))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,0,0],[0,1,0],[0,0,0]]").Result2dArray("[[0,0,0],[0,1,0],[0,0,0]]"))
          .Add(it => it.Param2dArray("[[0,0,0],[0,1,0],[1,1,1]]").Result2dArray("[[0,0,0],[0,1,0],[1,2,1]]"))
          .Add(it => it.Param2dArray("[[0,1,1],[1,1,1],[1,1,1]]").Result2dArray("[[0,1,2],[1,2,3],[2,3,4]]"))
          .Add(it => it.Param2dArray("[[1,1,1],[1,1,1],[1,1,0]]").Result2dArray("[[4,3,2],[3,2,1],[2,1,0]]"))
          .Add(it => it.Param2dArray("[[0,0,0],[0,1,1],[1,1,0]]").Result2dArray("[[0,0,0],[0,1,1],[1,1,0]]"))
          .Add(it => it.Param2dArray("[[0,1,1],[1,1,1],[1,1,0]]").Result2dArray("[[0,1,2],[1,2,1],[2,1,0]]"));

    private int[][] Solution(int[][] mat)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;

        int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        var result = Enumerable.Range(0, rows).Select(_ => Enumerable.Repeat(int.MaxValue, cols).ToArray()).ToArray();
        var queue = new Queue<(int x, int y)>();

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (mat[y][x] == 0)
                {
                    result[y][x] = 0;
                    queue.Enqueue((x, y));
                }
            }
        }

        while (queue.Any())
        {
            var current = queue.Dequeue();

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                var xd = current.x + directions[i, 0];
                var yd = current.y + directions[i, 1];

                if (xd >= 0 && xd < cols
                            && yd >= 0 && yd < rows
                            && result[yd][xd] > result[current.y][current.x] + 1)
                {
                    result[yd][xd] = result[current.y][current.x] + 1;

                    queue.Enqueue((xd, yd));
                }
            }
        }

        return result;
    }
}