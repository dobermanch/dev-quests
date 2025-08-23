// https://leetcode.com/problems/count-of-matches-in-tournament

namespace LeetCode.Problems;

public sealed class NumberOfMatches : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumberOfMatches))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(7).Result(6))
          .Add(it => it.Param(14).Result(13));

    private int Solution(int n)
    {
        var matches = 0;
        var teams = n;

        while (teams > 1)
        {
            matches += teams / 2;
            teams = teams / 2 + teams % 2;
        }

        return matches;
    }

    private int Solution2(int n)
    {
        return n - 1;
    }
}