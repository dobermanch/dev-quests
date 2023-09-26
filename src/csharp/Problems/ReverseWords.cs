//https://leetcode.com/problems/reverse-words-in-a-string

namespace LeetCode.Problems;

public sealed class ReverseWords : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseWords))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("the sky is blue").Result("blue is sky the"))
          .Add(it => it.Param("  hello world  ").Result("world hello"))
          .Add(it => it.Param("a good   example").Result("example good a"));

    private string Solution(string s)
    {
        var result = new StringBuilder();
        var left = 0;
        var right = 0;
        while(right <= s.Length)
        {
            if (right < s.Length && s[right] != ' ')
            {
                right++;
                continue;
            }

            if (left != right)
            {
                if (result.Length > 0)
                {
                    result.Insert(0, ' ');
                }
                
                result.Insert(0, s[left..right]);
            }

            left = ++right;
        }

        return result.ToString();
    }
}