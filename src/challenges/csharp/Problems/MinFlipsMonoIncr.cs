//https://leetcode.com/problems/flip-string-to-monotone-increasing/description/

namespace LeetCode.Problems;

public sealed class MinFlipsMonoIncr : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinFlipsMonoIncr))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("00110").Result(1))
          .Add(it => it.Param("010110").Result(2))
          .Add(it => it.Param("00011000").Result(2))
        ;

    private int Solution(string s)
    {
        var flips = 0;

        var zeros = 0;
        var ones = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                ones++;
            }
            else if (++zeros > ones)
            {
                flips += ones;
                ones = 0;
                zeros = 0;
            }
        }

        flips += ones > zeros ? zeros : ones;

        return flips;
    }
}