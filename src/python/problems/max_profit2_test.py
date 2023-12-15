# https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii

from core.problem_base import *

class MaxProfit2(ProblemBase):
    def Solution(self, prices: list[int]) -> int:
        profit = 0

        for i in range(1, len(prices)):
            if prices[i] > prices[i - 1]:
                profit += prices[i] - prices[i - 1]

        return profit

if __name__ == '__main__':
    TestGen(MaxProfit2) \
        .Add(lambda tc: tc.Param([7,1,5,3,6,4]).Result(7)) \
        .Add(lambda tc: tc.Param([1,2,3,4,5]).Result(4)) \
        .Add(lambda tc: tc.Param([7,6,4,3,1]).Result(0)) \
        .Run()
