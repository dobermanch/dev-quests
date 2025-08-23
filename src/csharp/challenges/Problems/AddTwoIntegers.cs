//https://leetcode.com/problems/add-two-integers/

namespace LeetCode.Problems;

public sealed class AddTwoIntegers : ProblemBase
{
    [Theory]
    [ClassData(typeof(AddTwoIntegers))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(10).Param(12).Result(22))
          .Add(it => it.Param(15).Param(12).Result(27));

    private int Solution(int num1, int num2)
    {
        if (num1 < -100 || num2 > 100)
        {
            throw new ArgumentException();
        }
        var carry = 0;
        while (num2 != 0)
        {
            carry = num1 & num2;
            num1 = num1 ^ num2;
            num2 = carry << 1;
        }
        return num1;
    }
}