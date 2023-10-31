//https://leetcode.com/problems/first-bad-version/

namespace LeetCode.Problems;

public sealed class FirstBadVersion : ProblemBase
{
    [Theory]
    [ClassData(typeof(FirstBadVersion))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(30).Result(11))
            .Add(it => it.Param(1).Result(1));

    private int Solution(int n)
    {
        var start = 0;
        var end = n;
        var result = 1;
        do
        {
            var version = start + (end - start) / 2;
            if (IsBadVersion(version))
            {
                result = version;
                end = version - 1;
            }
            else
            {
                start = version + 1;
            }
        }
        while (start <= end);

        return result;
    }

    static bool IsBadVersion(int version)
    {
        return version > 10;
    }
}