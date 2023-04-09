//https://leetcode.com/problems/longest-common-subsequence/

namespace LeetCode.Problems;

public sealed class LongestCommonSubsequence : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestCommonSubsequence))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("abcde").Param("ace").Result(3))
          .Add(it => it.Param("bsbininm").Param("jmjkbkjkv").Result(1))
          .Add(it => it.Param("abcba").Param("abcbcba").Result(5))
          .Add(it => it.Param("abcde").Param("dbc").Result(2))
          .Add(it => it.Param("oxcpqrsvwf").Param("shmtulqrypy").Result(2))
          .Add(it => it.Param("abcde").Param("acf").Result(2))
          .Add(it => it.Param("abcde").Param("cef").Result(2))
          .Add(it => it.Param("abc").Param("abc").Result(3))
          .Add(it => it.Param("abc").Param("def").Result(0));

    private int Solution(string text1, string text2)
    {
        var map = new int[text2.Length + 1, text1.Length + 1];

        for (int i = text2.Length - 1; i >= 0; i--)
        {
            for (int j = text1.Length - 1; j >= 0; j--)
            {
                map[i, j] = text1[j] == text2[i] 
                    ? map[i + 1, j + 1] + 1 
                    : Math.Max(map[i, j + 1], map[i + 1, j]);
            }
        }

        return map[0, 0];
    }
}