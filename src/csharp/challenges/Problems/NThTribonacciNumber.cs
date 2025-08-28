//https://leetcode.com/problems/n-th-tribonacci-number/

namespace LeetCode.Problems;

public sealed class Tribonacci : ProblemBase
{
    [Theory]
    [ClassData(typeof(Tribonacci))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param(4).Result(4))
          .Add(it => it.Param(25).Result(1389537));

    private int Solution(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n <= 2) 
        {
            return 1;
        }

        var n1 = 1;
        var n2 = 1;
        var n3 = 2;
        while (--n > 2)
        {
            var next = n1 + n2 + n3;
            n1 = n2;
            n2 = n3;
            n3 = next;
        }

        return n3;
    }
}