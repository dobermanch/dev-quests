//https://leetcode.com/problems/longest-valid-parentheses

namespace LeetCode.Problems;

public sealed class LongestValidParentheses : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestValidParentheses))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("()(()").Result(2))
          .Add(it => it.Param("()(())").Result(6))
          .Add(it => it.Param(")(())())").Result(6))
          .Add(it => it.Param(")(())(()").Result(4))
          .Add(it => it.Param(")())())").Result(2))
          .Add(it => it.Param("(()").Result(2))
          .Add(it => it.Param(")()())").Result(4))
          .Add(it => it.Param("").Result(0));

    private int Solution(string s)
    {
        var stack = new Stack<int>(new[] { -1 });
        var max = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] is '(')
            {
                stack.Push(i);
                continue;
            }

            stack.Pop();
            if (!stack.Any())
            {
                stack.Push(i);
            }
            else
            {
                max = Math.Max(max, i - stack.Peek());
            }
        }

        return max;
    }

    private int Solution1(string s)
    {
        var stack = new Stack<int>();
        var map = new int[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] is '(')
            {
                stack.Push(i);
            }
            else if (stack.Count > 0)
            {
                map[stack.Pop()] = 1;
                map[i] = 1;
            }
        }

        var max = 0;
        var current = 0;
        for (var i = 0; i < map.Length; i++)
        {
            current = map[i] == 1 ? current + 1 : 0;

            max = Math.Max(max, current);
        }

        return max;
    }
}