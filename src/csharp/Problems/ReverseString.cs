//https://leetcode.com/problems/reverse-string/

namespace LeetCode.Problems;

public sealed class ReverseString : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseString))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray('h','e','l','l','o').ResultArray('o','l','l','e','h'))
          .Add(it => it.ParamArray('H','a','n','n','a','h').ResultArray('h','a','n','n','a','H'));

    private char[] Solution(char[] s)
    {
        var start = 0;
        var end = s.Length - 1;

        while (start < end)
        {
            (s[start], s[end]) = (s[end--], s[start++]);
        }

        return s;
    }
}