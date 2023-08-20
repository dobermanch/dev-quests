//https://leetcode.com/problems/minimum-time-to-collect-all-apples-in-a-tree/

namespace LeetCode.Problems;

public sealed class MinTime : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinTime))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(7).Param2dArray("[[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]]").ParamArray<bool>("[false,false,true,false,true,true,false]").Result(8))
          .Add(it => it.Param(7).Param2dArray("[[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]]").ParamArray<bool>("[false,false,true,false,false,true,false]").Result(6))
          .Add(it => it.Param(7).Param2dArray("[[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]]").ParamArray<bool>("[false,false,false,false,false,false,false]").Result(0))
        ;

    private int Solution(int n, int[][] edges, IList<bool> hasApple)
    {
        var visitedVertices = new bool[n];
        var route = 0;
        var routes = new int[edges.Length];

        var joined = edges.Concat(edges.Select(it => new[] { it[1], it[0] }))
            .ToLookup(it => it[0], it => it[1]);

        route += Search(0, 0, joined, visitedVertices, hasApple);

        return route;
    }

    static int Search(int rootVertice, int vertice, ILookup<int, int> edges, bool[] visitedVertices, IList<bool> hasApple)
    {
        int route = 0;
        if (!visitedVertices[vertice])
        {
            visitedVertices[vertice] = true;
            foreach (var i in edges[vertice])
            {
                route += Search(vertice, i, edges, visitedVertices, hasApple);
            }

            if ((hasApple[vertice] || route > 0) && rootVertice != vertice)
            {
                route += 2;
            }
        }

        return route;
    }
}