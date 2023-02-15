//https://leetcode.com/problems/basic-calculator-ii/

namespace LeetCode.Problems;

public sealed class Calculate : ProblemBase
{
    [Theory]
    [ClassData(typeof(Calculate))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("3+2*2").Result(7))
          .Add(it => it.Param(" 3/2 ").Result(1))
          .Add(it => it.Param(" 3+5 / 2 ").Result(5))
          .Add(it => it.Param("2*2+3").Result(7))
          .Add(it => it.Param("2+2-3").Result(1))
          .Add(it => it.Param("2-2+3").Result(3))
          .Add(it => it.Param("2+3-4*5+7").Result(-8))
          .Add(it => it.Param("32+34-34*354*44/34+45-1").Result(-15466))
          .Add(it => it.Param("1+2*5/3+6/4*2").Result(6))
        ;

    private int Solution(string s)
    {
        var numbers = new Stack<int>();
        var operand = '+';
        var number = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                number *= 10;
                number += s[i] - '0';
            }

            if (!char.IsDigit(s[i]) && !char.IsWhiteSpace(s[i]) || i == s.Length - 1)
            {
                if (operand == '-')
                {
                    numbers.Push(-number);
                }
                else if (operand == '+')
                {
                    numbers.Push(number);
                }
                else if (operand == '*')
                {
                    numbers.Push(number * numbers.Pop());
                }
                else if (operand == '/')
                {
                    numbers.Push(numbers.Pop() / number);
                }

                operand = s[i];
                number = 0;
            }
        }

        return numbers.Sum();
    }
}