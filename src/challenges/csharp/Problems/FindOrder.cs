//https://leetcode.com/problems/course-schedule-ii/

namespace LeetCode.Problems;

public sealed class FindOrder : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindOrder))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Param2dArray("[[2,0],[1,0],[3,1],[3,2],[1,3]]").ResultArray("[]"))
            .Add(it => it.Param(3).Param2dArray("[[1,0],[1,2],[0,1]]").ResultArray("[]"))
            .Add(it => it.Param(3).Param2dArray("[[0,2],[1,2],[2,0]]").ResultArray("[]"))
            .Add(it => it.Param(3).Param2dArray("[[0,1],[0,2],[1,2]]").ResultArray("[2,1,0]"))
            .Add(it => it.Param(2).Param2dArray("[[0,1],[1,0]]").ResultArray("[]"))
            .Add(it => it.Param(2).Param2dArray("[[0,1]]").ResultArray("[1,0]"))
            .Add(it => it.Param(4).Param2dArray("[[1,0],[2,0],[3,1],[3,2]]").ResultArray("[0,1,2,3]"))
            .Add(it => it.Param(2).Param2dArray("[[1,0]]").ResultArray(0, 1))
            .Add(it => it.Param(1).Param2dArray("[]").ResultArray("[0]"))
            .Add(it => it.Param(2).Param2dArray("[]").ResultArray("[0,1]"));

    private int[] Solution(int numCourses, int[][] prerequisites)
    {
        var visited = new bool[numCourses, 2];

        var result = new List<int>(numCourses);

        var edges = prerequisites.ToLookup(it => it[0], it => it[1]);
        for (int course = 0; course < numCourses; course++)
        {
            if (Search(edges, course, visited, result))
            {
                return Array.Empty<int>();
            }
        }

        return result.ToArray();
    }

    bool Search(ILookup<int, int> edges, int course, bool[,] visited, IList<int> result)
    {
        if (visited[course, 1])
        {
            return true;
        }

        if (visited[course, 0])
        {
            return false;
        }

        visited[course, 0] = true;
        visited[course, 1] = true;
        foreach (var prereq in edges[course])
        {
            if (Search(edges, prereq, visited, result))
            {
                return true;
            }
        }

        visited[course, 1] = false;

        result.Add(course);

        return false;
    }
}