//https://leetcode.com/problems/perfect-squares

namespace LeetCode.Problems;

public sealed class NumSquares : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumSquares))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(12).Result(3))
          .Add(it => it.Param(4).Result(1))
          .Add(it => it.Param(2).Result(2))
          .Add(it => it.Param(3).Result(3))
          .Add(it => it.Param(13).Result(2));

    private int Solution(int n)
    {
        var map = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            map[i] = int.MaxValue;

            for (int j = 1; j <= i; j++)
            {
                var pow = j * j;
                if (i - pow < 0)
                {
                    break;
                }

                map[i] = Math.Min(map[i], map[i - pow] + 1);
            }
        }

        return map[n];
    }
}