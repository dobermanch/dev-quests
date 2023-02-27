//https://leetcode.com/problems/reverse-words-in-a-string-iii

namespace LeetCode.Problems;

public sealed class ReverseWords : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseWords))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("Let's take LeetCode contest").Result("s'teL ekat edoCteeL tsetnoc"))
          .Add(it => it.Param("God Ding").Result("doG gniD"));

    private string Solution(string s)
    {
        var result = new StringBuilder();

        var index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                result.Append(s[i]);
                index = result.Length;
            }
            else
            {
                result.Insert(index, s[i]);
            }
        }

        return result.ToString();
    }
}