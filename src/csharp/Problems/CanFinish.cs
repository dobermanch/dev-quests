//https://leetcode.com/problems/course-schedule/

namespace LeetCode.Problems;

public sealed class CanFinish : ProblemBase
{
    [Theory]
    [ClassData(typeof(CanFinish))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(2).Param2dArray("[[1,0]]").Result(true))
          .Add(it => it.Param(5).Param2dArray("[[1,4],[2,4],[3,1],[3,2]]").Result(true))
          .Add(it => it.Param(1).Param2dArray("[]").Result(true))
          .Add(it => it.Param(3).Param2dArray("[[1,0],[2,0],[1,2]]").Result(true))
          .Add(it => it.Param(2).Param2dArray("[[1,0],[0,1]]").Result(false));

    private bool Solution(int numCourses, int[][] prerequisites)
    {
        var dependencies = prerequisites.ToLookup(it => it[0], it => it[1]);

        var visited = new bool[numCourses, 2];

        foreach (var course in dependencies.Select(it => it.Key))
        {
            if (!Visit(dependencies, course, visited))
            {
                return false;
            }
        }

        return true;
    }

    bool Visit(ILookup<int, int> dependencies, int current, bool[,] visited)
    {
        if (visited[current, 1])
        {
            return false;
        }

        if (visited[current, 0])
        {
            return true;
        }

        visited[current, 0] = true;
        visited[current, 1] = true;

        foreach (var course in dependencies[current])
        {
            if (!Visit(dependencies, course, visited))
            {
                return false;
            }
        }

        visited[current, 1] = false;

        return true;
    }
}