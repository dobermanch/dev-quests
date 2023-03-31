//https://leetcode.com/problems/longest-palindrome/

namespace LeetCode.Problems;

public sealed class LongestPalindrome : ProblemBase
{
    [Theory]
    [ClassData(typeof(LongestPalindrome))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("abccccdd").Result(7))
            .Add(it => it.Param("a").Result(1));

    private int Solution(string s)
    {
        var map = new int[58];
        for (var i = 0; i < s.Length; i++)
        {
            map[s[i] - 'A']++;
        }

        var sum = 0;
        var addOne = false;
        for (var i = 0; i < map.Length; i++)
        {
            sum += map[i];
            if (map[i] % 2 != 0)
            {
                sum--;
                addOne = true;
            }
        }

        return addOne ? ++sum : sum;
    }
}