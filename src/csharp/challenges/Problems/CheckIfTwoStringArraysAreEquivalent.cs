//https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent

namespace LeetCode.Problems;

public sealed class ArrayStringsAreEqual : ProblemBase
{
    [Theory]
    [ClassData(typeof(ArrayStringsAreEqual))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray<string>("""["ab", "c"]""").ParamArray<string>("""["a", "bc"]""").Result(true))
          .Add(it => it.ParamArray<string>("""["a", "cb"]""").ParamArray<string>("""["ab", "c"]""").Result(false))
          .Add(it => it.ParamArray<string>("""["abc", "d", "defg"]""").ParamArray<string>("""["abcddefg"]""").Result(true));

    private bool Solution(string[] word1, string[] word2)
    {
        string build(string[] words)
        {
            var builder = new StringBuilder();
            foreach (var word in words)
            {
                builder.Append(word);
            }

            return builder.ToString();
        }

        return build(word1) == build(word2);
    }
}