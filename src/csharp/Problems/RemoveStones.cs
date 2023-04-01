//https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/

using System.Collections.Specialized;

namespace LeetCode.Problems;

public sealed class RemoveStones : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveStones))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => //AddSolutions(nameof(Solution1))
           Add(it => it.Param2dArray("[[0,1],[1,0]]").Result(0))
          .Add(it => it.Param2dArray("[[3,2],[3,1],[4,4],[1,1],[0,2],[4,0]]").Result(4))
          .Add(it => it.Param2dArray("[[3,2],[3,1],[4,4],[1,1],[0,2],[4,0],[2,0]]").Result(5))
          .Add(it => it.Param2dArray("[[0,1],[0,2],[4,3],[2,4],[0,3],[1,1]]").Result(4))
          .Add(it => it.Param2dArray("[[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]").Result(5))
          .Add(it => it.Param2dArray("[[0,0],[0,2],[1,1],[2,0],[2,2]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0],[0,2],[1,1],[2,0],[2,2]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0],[0,1],[1,0],[1,1]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0]]").Result(0));

    //private int Solution(int[][] stones)
    //{
    //    var parents = Enumerable.Range(0, stones.Length).Select(it => new[] { it, 0 }).ToArray();
    //    var count = 0;
    //    for (var i = 0; i < stones.Length; i++)
    //    {
    //        var yRoot = Find(parents, stones[i][0]);
    //        var xRoot = Find(parents, stones[i][1]);
    //        if (yRoot != xRoot)
    //        {
    //            if (parents[yRoot][1] >= parents[xRoot][1])
    //            {
    //                parents[xRoot][0] = parents[yRoot][0];
    //                parents[yRoot][1]++;
    //            }
    //            else
    //            {
    //                //parents[yRoot][0] = parents[xRoot][0];
    //                parents[xRoot][1]++;
    //            }
    //        }
    //        else
    //        {
    //            parents[yRoot][1]++;
    //        }

    //    }

    //    var diff = parents.Where(it => it[1] > 0).Select(it => it[1] - 1).Count();
    //    return diff;
    //}

    //private int Find(int[][] parents, int index)
    //{
    //    if (parents[index][0] != index)
    //    {
    //        parents[index][0] = Find(parents, parents[index][0]);
    //    }

    //    return parents[index][0];
    //}

    private int Solution(int[][] stones)
    {
        int Dfs(int[][] data, int index, bool[] visited)
        {
            if (index >= data.Length || visited[index])
            {
                return 0;
            }

            visited[index] = true;

            var count = 1;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[index][0] == data[i][0] || data[index][1] == data[i][1])
                {
                    count += Dfs(data, i, visited);
                }
            }

            return count;
        }

        int count = 0;
        var visited = new bool[stones.Length];
        for (var i = 0; i < stones.Length; i++)
        {
            if (!visited[i])
            {
                count += Dfs(stones, i, visited) - 1;
            }
        }

        return count;
    }
}