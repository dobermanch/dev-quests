//https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string

namespace LeetCode.Problems;

public sealed class StrStr : ProblemBase
{
    [Theory]
    [ClassData(typeof(StrStr))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("sadbutsad").Param("sad").Result(0))
          .Add(it => it.Param("a").Param("a").Result(0))
          .Add(it => it.Param("leetcode").Param("leeto").Result(-1));

    private int Solution(string haystack, string needle)
    {
        var length = haystack.Length - needle.Length;
        for (var index = 0; index <= length; index++)
        {
            if (haystack[index] != needle[0])
            {
                continue;
            }

            var left = 0;
            var right = needle.Length - 1;
            while (left <= right
                    && haystack[index + left] == needle[left]
                    && haystack[index + right] == needle[right])
            {
                left++;
                right--;
            }

            if (left > right)
            {
                return index;
            }
        }

        return -1;
    }
}