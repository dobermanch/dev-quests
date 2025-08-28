// https://leetcode.com/problems/integer-to-roman

namespace LeetCode.Problems;

public sealed class IntToRoman : ProblemBase
{
    [Theory]
    [ClassData(typeof(IntToRoman))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(3490).Result("MMMCDXC"))
          .Add(it => it.Param(3).Result("III"))
          .Add(it => it.Param(58).Result("LVIII"))
          .Add(it => it.Param(1994).Result("MCMXCIV"));

    private string Solution(int num)
    {
        var map = new Dictionary<int, string> {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000,"M" },
        };

        var result = new StringBuilder();
        var acc = 1;
        while (num > 0)
        {
            var reminder = num % 10;
            var number = reminder * acc;
            num /= 10;

            if (reminder > 0)
            {
                result.Insert(
                    0,
                    reminder switch
                    {
                        <= 3 => new string(map[acc][0], reminder),
                        4 => map[acc] + map[number + acc],
                        > 5 and <= 8 => map[5 * acc] + new string(map[acc][0], reminder - 5),
                        9 => map[acc] + map[acc * 10],
                        _ => map[number],
                    });
            }

            acc *= 10;
        }

        return result.ToString();
    }
}