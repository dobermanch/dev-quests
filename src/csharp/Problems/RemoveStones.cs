//https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/

namespace LeetCode.Problems;

public sealed class RemoveStones : ProblemBase
{
    [Theory]
    [ClassData(typeof(RemoveStones))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]").Result(5))
          .Add(it => it.Param2dArray("[[0,0],[0,2],[1,1],[2,0],[2,2]]").Result(3))
          .Add(it => it.Param2dArray("[[0,0]]").Result(0));

    private int Solution(int[][] stones)
    {
        return 0;
    }
}