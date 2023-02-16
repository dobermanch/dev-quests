//https://leetcode.com/problems/number-of-provinces/

namespace LeetCode.Problems;

public sealed class FindCircleNum : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindCircleNum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,1,0],[1,1,0],[0,0,1]]").Result(2))
          .Add(it => it.Param2dArray("[[1,0,0],[0,1,0],[0,0,1]]").Result(3));

    private int Solution(int[][] isConnected)
    {
        return 0;
    }
}