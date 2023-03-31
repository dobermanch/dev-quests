//https://leetcode.com/problems/add-strings/

namespace LeetCode.Problems;

public sealed class AddStrings : ProblemBase
{
    [Theory]
    [ClassData(typeof(AddStrings))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("10").Param("12").Result("22"))
          .Add(it => it.Param("152").Param("12").Result("164"))
          .Add(it => it.Param("15").Param("122").Result("137"))
          .Add(it => it.Param("15").Param("0").Result("15"))
          .Add(it => it.Param("0").Param("15").Result("15"))
          .Add(it => it.Param("1233").Param("15").Result("1248"))
          .Add(it => it.Param("15").Param("12").Result("27"));

    private string Solution(string num1, string num2)
    {
        var length = Math.Max(num1.Length, num2.Length);

        var diff = new string(Enumerable.Repeat('0', Math.Abs(num2.Length - num1.Length)).ToArray());
        if (num1.Length < num2.Length)
        {
            num1 = diff + num1;
        }
        else
        {
            num2 = diff + num2;
        }

        var result = new StringBuilder();
        var carry = 0;
        for (var i = length - 1; i >= 0; i--)
        {
            var add = carry + (num1[i] - '0') + (num2[i] - '0');
            carry = add / 10;
            add %= 10;

            result.Insert(0, add);
        }

        if (carry > 0)
        {
            result.Insert(0, carry);
        }

        return result.ToString();
    }
}