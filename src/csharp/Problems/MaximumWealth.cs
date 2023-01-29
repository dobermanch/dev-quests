//https://leetcode.com/problems/richest-customer-wealth/

namespace LeetCode.Problems;

public sealed class MaximumWealth : ProblemBase
{
    public static void Run()
    {
        var result = Run(new [] {new [] { 1,2,3}, new [] {3,2,1} }); // 6
        //var result = Run(new [] {new [] { 1,5}, new [] {7,3}, new [] {3,5} }); // 10
        //var result = Run(new [] {new [] { 2,8,7}, new [] {7,1,3}, new [] {1,9,5} }); // 17
    }

    private static int Run(int[][] accounts) 
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