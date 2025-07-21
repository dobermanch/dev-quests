//https://leetcode.com/problems/length-of-last-word

namespace LeetCode.Problems;

public sealed class LengthOfLastWord : ProblemBase
{
    [Theory]
    [ClassData(typeof(LengthOfLastWord))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("a").Result(1))
          .Add(it => it.Param("Hello World").Result(5))
          .Add(it => it.Param("   fly me   to   the moon  ").Result(4))
          .Add(it => it.Param("qWnqNICa   ADGZNrBw  DdxMEuhNuvTJaETF   KhKKfVFX").Result(8))
          .Add(it => it.Param("luffy is still joyboy").Result(6));

    private int Solution(string s)
    {
        var startAt = -1;
        var endAt = -1;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (startAt == -1 && char.IsLetter(s[i]))
            {
                startAt = i;
            }
            else if (startAt != -1 && char.IsWhiteSpace(s[i]))
            {
                endAt = i;
                break;
            }
        }

        return startAt - endAt;
    }
}