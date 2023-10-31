//https://leetcode.com/problems/generate-parentheses/

using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace LeetCode.Problems;

public sealed class GenerateParenthesis : ProblemBase
{
    [Theory]
    [ClassData(typeof(GenerateParenthesis))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(3).ResultArray<string>("""["((()))","(()())","(())()","()(())","()()()"]"""))
          .Add(it => it.Param(2).ResultArray<string>("""["(())","()()"]"""))
          .Add(it => it.Param(1).ResultArray<string>("""["()"]"""))
        ;

    private IList<string> Solution(int n)
    {
        var result = new List<string>();
        Build(n - 1, n, '(', new List<char>(), result);
        return result;
    }

    private void Build(int open, int closed, char parenthesis, IList<char> temp, IList<string> result)
    {
        temp.Add(parenthesis);
        if (open > 0)
        {
            Build(open - 1, closed, '(', temp, result);
        }

        if (closed > open)
        {
            Build(open, closed - 1, ')', temp, result);
        }

        if (open == 0 && closed == 0)
        {
            result.Add(new string(temp.ToArray()));
        }

        temp.RemoveAt(temp.Count - 1);
    }
}