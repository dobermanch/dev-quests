//https://leetcode.com/problems/largest-3-same-digit-number-in-string

namespace LeetCode.Problems;

public sealed class LargestGoodInteger : ProblemBase
{
    [Theory]
    [ClassData(typeof(LargestGoodInteger))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("6777133339").Result("777"))
          .Add(it => it.Param("2300019").Result("000"))
          .Add(it => it.Param("42352338").Result(""));

    private string Solution(string num)
    {
        var result = '\0';
        var digit = num[0];
        var count = 1;
        const int targetCount = 3;
        for(var i = 1; i < num.Length; i++)
        {
            if (num[i] != digit)
            {
                digit = num[i];
                count = 1;
                continue;
            }

            if (++count >= targetCount && digit > result)
            {
                result = digit;
            }
        }

        return result is '\0' ? string.Empty : new string(result, targetCount);
    }
}