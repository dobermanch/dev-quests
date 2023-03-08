//https://leetcode.com/problems/valid-parentheses/

namespace LeetCode.Problems;

public sealed class IsValidParentheses : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsValidParentheses))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("()").Result(true))
          .Add(it => it.Param("()[]{}").Result(true))
          .Add(it => it.Param("(]").Result(false))
          .Add(it => it.Param("{").Result(false))
          .Add(it => it.Param("{[").Result(false))
          .Add(it => it.Param("]").Result(false))
          .Add(it => it.Param("]}").Result(false))
          .Add(it => it.Param("({[]([])})").Result(true));

    private bool Solution(string s)
    {
        var stack = new Stack<char>();
        foreach (var ch in s)
        {
            if (ch is '(' or '{' or '[')
            {
                stack.Push(ch);
                continue;
            }

            if (!stack.TryPop(out var bracket))
            {
                return false;
            }

            switch (ch)
            {
                case ')' when bracket != '(':
                case '}' when bracket != '{':
                case ']' when bracket != '[':
                    return false;
            }
        }

        return !stack.Any();
    }
}