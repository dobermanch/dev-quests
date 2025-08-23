# https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee

from core.problem_base import *

class MaxProfitFee(ProblemBase):
    def Solution(self, prices: list[int], fee: int) -> int:
        temp = -prices[0]
        profit = 0

        for price in prices:
            temp = max(temp, profit - price)
            profit = max(profit, temp + price - fee)
        
        return profit

if __name__ == '__main__':
    TestGen(MaxProfitFee) \
        .Add(lambda tc: tc.Param([1,3,2,8,4,9]).Param(2).Result(8)) \
        .Add(lambda tc: tc.Param([1,3,7,5,10,3]).Param(3).Result(6)) \
        .Run()
