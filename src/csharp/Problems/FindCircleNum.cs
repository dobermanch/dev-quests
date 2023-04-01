//https://leetcode.com/problems/number-of-provinces/

using System.ComponentModel;

namespace LeetCode.Problems;

public sealed class FindCircleNum : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindCircleNum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1,0],[1,1,0],[0,0,1]]").Result(2))
          .Add(it => it.Param2dArray("[[1,0,0],[0,1,0],[0,0,1]]").Result(3))
          .Add(it => it.Param2dArray("[[1,0,0,1],[0,1,1,0],[0,1,1,1],[1,0,1,1]]").Result(1))
          .Add(it => it.Param2dArray("[[1,0,0,1,0,1],[0,1,0,0,1,0],[0,0,1,0,0,1],[1,0,0,1,1,0],[0,1,0,1,1,0],[1,0,1,0,0,1]]").Result(1))
          .Add(it => it.Param2dArray("[[1,0,0,1,0,1],[0,1,0,0,1,0],[0,0,1,0,0,1],[1,0,0,1,0,0],[0,1,0,0,1,0],[1,0,1,0,0,1]]").Result(2));

    private int Solution(int[][] isConnected)
    {
        var parents = Enumerable.Range(0, isConnected.Length).Select(it => new[] {it ,0}).ToArray();

        var count = isConnected.Length;
        for (int y = 0; y < isConnected.Length; y++)
        {
            for (int x = y + 1; x < isConnected[y].Length; x++)
            {
                if (y == x || isConnected[y][x] != 1)
                {
                    continue;
                }

                var yRoot = Find(parents, y);
                var xRoot = Find(parents, x);
                if (yRoot != xRoot)
                {
                    if (parents[xRoot][1] < parents[yRoot][1])
                    {
                        parents[xRoot][0] = parents[yRoot][0];
                    }
                    else
                    {
                        parents[yRoot][0] = parents[xRoot][0];
                        if (parents[xRoot][1] == parents[yRoot][1])
                        {
                            parents[xRoot][1]++;
                        }
                    }

                    count--;
                }
            }
        }

        return count;
    }

    private int Find(int[][] parents, int index)
    {
        if (parents[index][0] != index)
        {
            parents[index][0] = Find(parents, parents[index][0]);
        }

        return parents[index][0];
    }
}