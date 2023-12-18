//https://leetcode.com/problems/zigzag-conversion

namespace LeetCode.Problems;

public sealed class Convert : ProblemBase
{
    [Theory]
    [ClassData(typeof(Convert))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("AB").Param(1).Result("AB"))
          .Add(it => it.Param("PAYPALISHIRING").Param(3).Result("PAHNAPLSIIGYIR"))
          .Add(it => it.Param("PAYPALISHIRING").Param(4).Result("PINALSIGYAHRPI"))
          .Add(it => it.Param("A").Param(1).Result("A"));

    private string Solution(string s, int numRows)
    {
        var builders = Enumerable.Range(0, numRows).Select(it => new StringBuilder()).ToArray();

        var count = 0;
        var direction = 1;
        for (var i = 0; i < s.Length; i++)
        {
            builders[count].Append(s[i]);

            if (count == 0)
            {
                direction = 1;
            }
            else if (count == numRows - 1)
            {
                direction = -1;
            }

            count += direction;
        }

        return string.Join("", builders.Select(it => it.ToString()));
    }
}