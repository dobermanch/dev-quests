//https://leetcode.com/problems/reverse-words-in-a-string-iii

namespace LeetCode.Problems;

public sealed class ReverseWords3 : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseWords3))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("Let's take LeetCode contest").Result("s'teL ekat edoCteeL tsetnoc"))
          .Add(it => it.Param("God Ding").Result("doG gniD"));

    private string Solution(string s)
    {
        var result = new StringBuilder();

        var index = 0;
        foreach (var ch in s)
        {
            if (ch == ' ')
            {
                result.Append(ch);
                index = result.Length;
            }
            else
            {
                result.Insert(index, ch);
            }
        }

        return result.ToString();
    }
}