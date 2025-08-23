//https://leetcode.com/problems/largest-odd-number-in-string

namespace LeetCode.Problems;

public sealed class LargestOddNumber : ProblemBase
{
    [Theory]
    [ClassData(typeof(LargestOddNumber))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("52").Result("5"))
          .Add(it => it.Param("4206").Result(""))
          .Add(it => it.Param("35427").Result("35427"));

    private string Solution(string num) {
        for (var i = num.Length - 1; i >= 0; i--)
        {
            if (num[i] % 2 != 0)
            {
                return num[..(i+1)];
            }
        }

        return string.Empty;
    }
}