//https://leetcode.com/problems/evaluate-reverse-polish-notation/

namespace LeetCode.Problems;

public sealed class EvalRPN : ProblemBase
{
    [Theory]
    [ClassData(typeof(EvalRPN))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["2","1","+","3","*"]""").Result(9))
          .Add(it => it.ParamArray<string>("""["4","13","5","/","+"]""").Result(6))
          .Add(it => it.ParamArray<string>("""["10","6","9","3","+","-11","*","/","*","17","+","5","+"]""").Result(22));

    private int Solution(string[] tokens)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            if (int.TryParse(tokens[i], out var number))
            {
                stack.Push(number);
                continue;
            }

            var operand = tokens[i];
            if (operand == "+")
            {
                var right = stack.Pop();
                stack.Push(stack.Pop() + right);
            }
            else if (operand == "-")
            {
                var right = stack.Pop();
                stack.Push(stack.Pop() - right);
            }
            else if (operand == "*")
            {
                var right = stack.Pop();
                stack.Push(stack.Pop() * right);
            }
            else if (operand == "/")
            {
                var right = stack.Pop();
                stack.Push(stack.Pop() / right);
            }
        }

        return stack.Pop();
    }
}