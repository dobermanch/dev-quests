//https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c

namespace LeetCode.Problems;

public sealed class MinFlips : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinFlips))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(5).Param(2).Param(8).Result(4))
          .Add(it => it.Param(2).Param(6).Param(5).Result(3))
          .Add(it => it.Param(4).Param(2).Param(7).Result(1))
          .Add(it => it.Param(1).Param(2).Param(3).Result(0));

    private int Solution(int a, int b, int c)
    {
        var result = 0;
        for (int i = 0; i < 32; i++)
        {
            var ar = (1 << i) & a;
            var br = (1 << i) & b;
            var cr = (1 << i) & c;

            if ((ar | br) == cr)
            {
                continue;
            }
            else if (ar == 0 && br == 0)
            {
                result++;
                continue;
            }

            if (ar > 0)
            {
                result++;
            }

            if (br > 0)
            {
                result++;
            }
        }

        return result;
    }
}