//https://leetcode.com/problems/decode-ways/

namespace LeetCode.Problems;

public sealed class NumDecodings : ProblemBase
{
    [Theory]
    [ClassData(typeof(NumDecodings))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("1241").Result(3))
          .Add(it => it.Param("1010").Result(1))
          .Add(it => it.Param("1201234").Result(3))
          .Add(it => it.Param("10").Result(1))
          .Add(it => it.Param("230").Result(0))
          .Add(it => it.Param("27").Result(1))
          .Add(it => it.Param("2611055971756562").Result(4))
          .Add(it => it.Param("123123").Result(9))
          .Add(it => it.Param("1123").Result(5))
          .Add(it => it.Param("12122").Result(8))
          .Add(it => it.Param("12041").Result(1))
          .Add(it => it.Param("226").Result(3))
          .Add(it => it.Param("12").Result(2))
          .Add(it => it.Param("110").Result(1))
          .Add(it => it.Param("01241").Result(0))
          .Add(it => it.Param("123100532").Result(0))
          .Add(it => it.Param("06").Result(0));

    private int Solution(string s)
    {
        var temp1 = 1;
        var temp2 = 1;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var temp = temp1;

            if (s[i] == '0')
            {
                temp1 = 0;
            }
            else if (i + 1 < s.Length && (s[i] == '1' || s[i] == '2' && s[i + 1] <= '6'))
            {
                temp1 += temp2;
            }

            temp2 = temp;
        }

        return temp1;
    }
}