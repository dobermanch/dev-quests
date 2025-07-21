//https://leetcode.com/problems/find-the-town-judge/description/

namespace LeetCode.Problems;

public sealed class FindJudge : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindJudge))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(2).Param2dArray("[[1,2]]").Result(2))
            .Add(it => it.Param(3).Param2dArray("[[1,3],[2,3]]").Result(3))
            .Add(it => it.Param(3).Param2dArray("[[1,3],[2,3],[3,1]]").Result(-1));

    private int Solution(int n, int[][] trust)
    {
        var map = new int[n, 2];

        for (var i = 0; i < trust.Length; i++)
        {
            map[trust[i][1] - 1, 0] += 1;
            map[trust[i][0] - 1, 1] = 1;
        }

        for (var i = 0; i < n; i++)
        {
            if (map[i, 0] == n - 1 && map[i, 1] == 0)
            {
                return i + 1;
            }
        }

        return -1;
    }
}