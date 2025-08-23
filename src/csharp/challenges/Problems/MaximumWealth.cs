//https://leetcode.com/problems/richest-customer-wealth/

namespace LeetCode.Problems;

public sealed class MaximumWealth : ProblemBase
{
    [Theory]
    [ClassData(typeof(MaximumWealth))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray("[[1,2,3],[3,2,1]]").Result(6))
          .Add(it => it.Param2dArray("[[1,5],[7,3],[3,5]]").Result(10))
          .Add(it => it.Param2dArray("[[2,8,7],[7,1,3],[1,9,5]]").Result(17))
        ;

    private int Solution(int[][] accounts) 
    {
        var result = 0;
        for(var i = 0; i < accounts.Length; i++) {
            var amount = 0;
            for(var j = 0; j < accounts[i].Length; j++) {
                amount += accounts[i][j];
            }

            result = Math.Max(result, amount);
        }

        return result;
    }
}