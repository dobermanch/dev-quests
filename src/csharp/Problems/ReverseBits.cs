//https://leetcode.com/problems/reverse-bits/

namespace LeetCode.Problems;

public sealed class ReverseBits : ProblemBase
{
    [Theory]
    [ClassData(typeof(ReverseBits))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param<uint>(0b00000010100101000001111010011100).Result<uint>(964176192))
          .Add(it => it.Param<uint>(0b11111111111111111111111111111101).Result<uint>(3221225471));

    private uint Solution(uint n)
    {
        uint result = 0;
        for (int i = 31; i >= 0; i--)
        {
            if ((n & (1 << i)) != 0)
            {
                result |= (1u << (31 - i));
            }
        }

        return result;
    }
}