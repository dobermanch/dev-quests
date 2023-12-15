// https://leetcode.com/problems/destination-city

namespace LeetCode.Problems;

public sealed class DestCity : ProblemBase
{
    [Theory]
    [ClassData(typeof(DestCity))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<string>("""[["London","New York"],["New York","Lima"],["Lima","Sao Paulo"]]""").Result("Sao Paulo"))
          .Add(it => it.Param2dArray<string>("""[["B","C"],["D","B"],["C","A"]]""").Result("A"))
          .Add(it => it.Param2dArray<string>("""[["A","Z"]]""").Result("Z"));

    private string Solution(string[][] paths)
    {
        var map = new Dictionary<string, int>();
        foreach (var path in paths)
        {
            map[path[0]] = map.GetValueOrDefault(path[0]) + 1;
            map[path[1]] = map.GetValueOrDefault(path[1]);
        }

        return map.First(it => it.Value == 0).Key;
    }
}