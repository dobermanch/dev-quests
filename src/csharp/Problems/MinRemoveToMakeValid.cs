//https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/

namespace LeetCode.Problems;

public sealed class MinRemoveToMakeValid : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinRemoveToMakeValid))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("lee(t(c)o)de)").Result("lee(t(c)o)de"))
          .Add(it => it.Param("a)b(c)d").Result("ab(c)d"))
          .Add(it => it.Param("a)b()c)d").Result("ab()cd"))
          .Add(it => it.Param("))((").Result(""));

    private string Solution(string s)
    {
        var stack = new Stack<int>();

        var result = new StringBuilder();
        foreach (var ch in s)
        {
            result.Append(ch);
            switch (ch)
            {
                case '(':
                    stack.Push(result.Length - 1);
                    break;
                case ')' when stack.Count > 0:
                    stack.Pop();
                    break;
                case ')':
                    result.Remove(result.Length - 1, 1);
                    break;
            }
        }

        while (stack.Any())
        {
            result.Remove(stack.Pop(), 1);
        }

        return result.ToString();
    }
}