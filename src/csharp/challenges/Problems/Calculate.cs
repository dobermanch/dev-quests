//https://leetcode.com/problems/basic-calculator

namespace LeetCode.Problems;

public sealed class Calculate : ProblemBase
{
    [Theory]
    [ClassData(typeof(Calculate))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("- (3 - (- (4 + 5) ) )").Result(-12))
          .Add(it => it.Param("(1+(4+5+2)-3)+(6+8)").Result(23))
          .Add(it => it.Param("- (3 + (4 + 5))").Result(-12))
          .Add(it => it.Param("-2+ 1").Result(-1))
          .Add(it => it.Param("1 + 1").Result(2))
          .Add(it => it.Param(" 2-1 + 2 ").Result(3));

    private int Solution(string s)
    {
        var numbers = new Stack<int>();
        var operand = 1;
        var number = 0;
        var result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                number *= 10;
                number += s[i] - '0';
            }

            if (!char.IsDigit(s[i]) || i == s.Length - 1)
            {
                result += number * operand;
                number = 0;
            }

            if (s[i] is '(')
            {
                numbers.Push(result);
                numbers.Push(operand);
                operand = 1;
                result = 0;
            }
            else if (s[i] is ')')
            {
                result *= numbers.Pop();
                result += numbers.Pop();
            }
            else if (s[i] == '-')
            {
                operand = -1;
            }
            else if (s[i] == '+')
            {
                operand = 1;
            }
        }

        return result;
    }

    private int Solution2(string s)
    {
        var numbers = new Stack<int>();
        var brackets = new Stack<(int pos, char sign)>();
        var operand = '+';
        var number = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                number *= 10;
                number += s[i] - '0';
            }

            if (s[i] is '(')
            {
                brackets.Push((numbers.Count, operand));
                operand = '+';
            }
            else if (!char.IsDigit(s[i]) && !char.IsWhiteSpace(s[i]) || i == s.Length - 1)
            {
                if (operand == '-')
                {
                    numbers.Push(-number);
                }
                else if (operand == '+')
                {
                    numbers.Push(number);
                }

                operand = s[i];
                number = 0;

                if (s[i] is ')')
                {
                    var (popTo, sign) = brackets.Pop();
                    var result = 0;
                    while (numbers.Count > popTo) 
                    {
                        result += numbers.Pop();
                    }

                    numbers.Push(sign == '-' ? -result : result);
                }
            }
        }

        return numbers.Sum();
    }
}