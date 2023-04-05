//https://leetcode.com/problems/add-strings/

namespace LeetCode.Problems;

public sealed class FindSmallestSetOfVertices : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindSmallestSetOfVertices))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(5).Param2dArray("[[1,3],[2,0],[2,3],[1,0],[4,1],[0,3]]").ResultArray("[2,4]"))
          .Add(it => it.Param(5).Param2dArray("[[1,3],[2,0],[2,3],[1,0],[4,1],[0,3],[3,4]]").ResultArray("[2]"))
          .Add(it => it.Param(6).Param2dArray("[[0,1],[0,2],[2,5],[3,4],[4,2]]").ResultArray("[0,3]"))
          .Add(it => it.Param(6).Param2dArray("[[0,1],[0,2],[2,5],[4,3],[3,2]]").ResultArray("[0,4]"))
          .Add(it => it.Param(5).Param2dArray("[[0,1],[2,1],[3,1],[1,4],[2,4]]").ResultArray("[0,2,3]"));

    private IList<int> Solution(int n, IList<IList<int>> edges)
    {
        var result = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
        {
            if (result.Contains(edge[1]))
            {
                result.Remove(edge[1]);
            }
        }

        return result.ToArray();
    }
}