// https://leetcode.com/problems/plus-one

namespace LeetCode.Problems;

public sealed class PlusOne : ProblemBase
{
    [Theory]
    [ClassData(typeof(PlusOne))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray("[1,2,3]").ResultArray("[1,2,4]"))
          .Add(it => it.ParamArray("[4,3,2,1]").ResultArray("[4,3,2,2]"))
          .Add(it => it.ParamArray("[9]").ResultArray("[1,0]"))
          .Add(it => it.ParamArray("[9,5,6,4,6,7,5,7,5,7,7,9,9,9,9]").ResultArray("[9,5,6,4,6,7,5,7,5,7,8,0,0,0,0]"));

    private int[] Solution(int[] digits)
    {
        var result = new int[digits.Length + 1];
        result[0] = 1;
        var carry = 1;
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var temp = digits[i] + carry;
            carry = temp / 10;
            result[i + 1] = temp % 10;
        }

        return carry > 0 ? result : result[1..];
    }
}