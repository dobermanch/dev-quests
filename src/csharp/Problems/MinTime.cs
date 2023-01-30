namespace LeetCode.Problems;

public sealed class MinTime : ProblemBase
{
    static (int[][], bool[], int) Case1()
        => (new int[][]{
                new []{0,1},
                new []{0,2},
                new []{1,4},
                new []{1,5},
                new []{2,3},
                new []{2,6}
            },
            new[] { false, false, true, false, true, true, false },
            7);

    static (int[][], bool[], int) Case2()
        => (new int[][]{
                new []{0,2},
                new []{0,3},
                new []{1,2}
            },
            new[] { false, true, false, false },
            4);

    static (int[][], bool[], int) Case3()
        => (new int[][]{
                new []{0,1},
                new []{1,2},
                new []{0,3}
            },
            new[] { true, true, true, true },
            4);

    public static void Run()
    {
        var testData = Case1();
        Run(testData.Item3, testData.Item1, testData.Item2);
    }

    static int Run(int n, int[][] edges, IList<bool> hasApple)
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