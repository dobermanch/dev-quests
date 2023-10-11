//https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/

namespace LeetCode.Problems;

public sealed class MinReorder : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinReorder))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(6).Param2dArray("[[0,2],[0,3],[4,1],[4,5],[5,0]]").Result(3))
          .Add(it => it.Param(6).Param2dArray("[[0,1],[1,3],[2,3],[4,0],[4,5]]").Result(3))
          .Add(it => it.Param(5).Param2dArray("[[1,0],[1,2],[3,2],[3,4]]").Result(2))
          .Add(it => it.Param(5).Param2dArray("[[4,3],[2,3],[1,2],[1,0]]").Result(2))
          .Add(it => it.Param(3).Param2dArray("[[1,0],[2,0]]").Result(0))
          .Add(it => it.Param(3).Param2dArray("[[1,2],[2,0]]").Result(0));

    private int Solution(int n, int[][] connections)
    {
        var neighbors = Enumerable
                    .Range(0, n)
                    .ToDictionary(it => it, it => new List<(int city, bool change)>());
        foreach (var edge in connections)
        {
            neighbors[edge[0]].Add((edge[1], true));
            neighbors[edge[1]].Add((edge[0], false));
        }

        return Search(neighbors, 0, new bool[n]);
    }

    int Search(IDictionary<int, List<(int city, bool change)>> neighbors, int current, bool[] visited)
    {
        var result = 0;
        visited[current] = true;
        foreach(var (city, change) in neighbors[current])
        {
            if (visited[city])
            {
                continue;
            }

            if (change)
            {
                result += 1;
            }

            result += Search(neighbors, city, visited);
        }

        return result;
    }
}