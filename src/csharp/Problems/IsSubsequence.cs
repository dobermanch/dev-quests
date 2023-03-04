//https://leetcode.com/problems/is-subsequence/

namespace LeetCode.Problems;

public sealed class IsSubsequence : ProblemBase
{
    [Theory]
    [ClassData(typeof(IsSubsequence))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("abc").Param("ahbgdc").Result(true))
          .Add(it => it.Param("axc").Param("ahbgdc").Result(false));

    private bool Solution(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        if (string.IsNullOrEmpty(t))
        {
            return false;
        }

        var j = 0;
        for (var i = 0; i < t.Length; i++)
        {
            if (t[i] == s[j])
            {
                j++;
                if (j >= s.Length)
                {
                    break;
                }
            }
        }

        return j == s.Length;
    }
}