//https://leetcode.com/problems/bulls-and-cows/description

namespace LeetCode.Problems;

public sealed class GetHint : ProblemBase
{
    [Theory]
    [ClassData(typeof(GetHint))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("1807").Param("7810").Result("1A3B"))
          .Add(it => it.Param("1123").Param("0111").Result("1A1B"))
          .Add(it => it.Param("1122").Param("1222").Result("3A0B"))
          .Add(it => it.Param("11225").Param("22111").Result("0A4B"))
        ;

    private string Solution(string secret, string guess)
    {
        var map = new int[10, 2];

        var bulls = 0;
        var cows = 0;
        for (var i = 0; i < guess.Length; i++)
        {
            if (guess[i] == secret[i])
            {
                bulls++;
            }
            else
            {
                map[secret[i] - '0', 0]++;
                map[guess[i] - '0', 1]++;
            }
        }

        for (var i = 0; i < map.GetLength(0); i++)
        {
            cows += Math.Min(map[i, 0], map[i, 1]);
        }

        return $"{bulls}A{cows}B";
    }
}