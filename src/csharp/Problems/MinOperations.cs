//https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string

namespace LeetCode.Problems;

public sealed class MinOperations : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinOperations))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("0100").Result(1))
          .Add(it => it.Param("10").Result(0))
          .Add(it => it.Param("1111").Result(2))
          .Add(it => it.Param("00010111").Result(2))
          .Add(it => it.Param("00001111").Result(4));

    private int Solution(string s)
    {
        var operations = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var mod = i % 2;
            if (mod == 0 && s[i] != '1'
                || mod != 0 && s[i] == '1')
            {
                operations++;
            }
        }

        return Math.Min(operations, s.Length - operations);
    }
}