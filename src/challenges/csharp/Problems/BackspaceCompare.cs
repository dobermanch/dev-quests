//https://leetcode.com/problems/backspace-string-compare/

namespace LeetCode.Problems;

public sealed class BackspaceCompare : ProblemBase
{
    [Theory]
    [ClassData(typeof(BackspaceCompare))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("ab#c").Param("ad#c").Result(true))
            .Add(it => it.Param("ab##").Param("c#d#").Result(true))
            .Add(it => it.Param("a#c").Param("b").Result(false))
            .Add(it => it.Param("a##c").Param("#a#c").Result(true))
            .Add(it => it.Param("y#f#o##f").Param("y#f#o##f").Result(true));

    private bool Solution(string s, string t)
    {
        Stack<char> GetStack(string str)
        {
            var stack = new Stack<char>();
            foreach (var s in str)
            {
                if (s != '#')
                {
                    stack.Push(s);
                }
                else if (stack.Any())
                {
                    stack.Pop();
                }
            }
            return stack;
        }

        var stackS = GetStack(s);
        var stackT = GetStack(t);

        return stackS.SequenceEqual(stackT);
    }
}