//https://leetcode.com/problems/path-crossing

namespace LeetCode.Problems;

public sealed class IsPathCrossing : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsPathCrossing))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("NES").Result(false))
          .Add(it => it.Param("NESWW").Result(true));

    private bool Solution(string path)
    {
        (int x, int y) point = (0, 0);

        var map = new HashSet<(int, int)>();
        map.Add(point);
        foreach (var direction in path)
        {
            point = direction switch
            {
                'N' => (point.x, point.y + 1),
                'S' => (point.x, point.y - 1),
                'E' => (point.x + 1, point.y),
                'W' or _ => (point.x - 1, point.y)
            };

            if (!map.Add(point))
            {
                return true;
            }
        }

        return false;
    }
}