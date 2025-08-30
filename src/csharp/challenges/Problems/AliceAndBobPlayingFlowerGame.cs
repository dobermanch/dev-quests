
// https://leetcode.com/problems/alice-and-bob-playing-flower-game

namespace LeetCode.Problems;

public sealed class AliceAndBobPlayingFlowerGame : ProblemBase
{
    [Theory]
    [ClassData(typeof(AliceAndBobPlayingFlowerGame))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(100000).Param(100000).Result(5000000000L))
          .Add(it => it.Param(10).Param(3).Result(15L))
          .Add(it => it.Param(3).Param(2).Result(3L))
          .Add(it => it.Param(1).Param(1).Result(0L))
        ;

    private long Solution(int n, int m)
    {
        long nEven = n / 2;
        long nOdd = (n + 1) / 2;

        long mEven = m / 2;
        long mOdd = (m + 1) / 2;

        return nEven * mOdd + nOdd * mEven;
    }
}
