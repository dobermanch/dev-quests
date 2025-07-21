// https://leetcode.com/problems/roman-to-integer

namespace LeetCode.Problems;

public sealed class RomanToInt : ProblemBase
{
    [Theory]
    [ClassData(typeof(RomanToInt))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("MMMCDXC").Result(3490))
          .Add(it => it.Param("III").Result(3))
          .Add(it => it.Param("LVIII").Result(58))
          .Add(it => it.Param("MCMXCIV").Result(1994));

    private int Solution(string s)
    {
        var map = new Dictionary<char, int> {
            { 'I', 1 },
            { 'V', 5 },
            { 'L', 50 },
            { 'X', 10 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        var result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result += i + 1 < s.Length && map[s[i]] < map[s[i + 1]] 
                ? -map[s[i]] 
                : map[s[i]];
        }

        return result;
    }
}