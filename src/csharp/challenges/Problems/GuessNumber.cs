// https://leetcode.com/problems/guess-number-higher-or-lower

namespace LeetCode.Problems;

public sealed class GuessNumber : ProblemBase
{
    [Theory]
    [ClassData(typeof(GuessNumber))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(10).Param(6).Result(6))
          .Add(it => it.Param(1).Param(1).Result(1))
          .Add(it => it.Param(2).Param(1).Result(1));

    private int Solution(int n, int pick)
    {
        int guess(int n)
            => n > pick ? -1 : n < pick ? 1 : 0;

        var left = 0;
        var right = n;
        var num = 0;
        while (left <= right)
        {
            num = left + (right - left) / 2;
            var result = guess(num);
            if (result == 0)
            {
                break;
            }
            else if (result == 1)
            {
                left = num + 1;
            }
            else
            {
                right = num - 1;
            }
        }

        return num;
    }
}