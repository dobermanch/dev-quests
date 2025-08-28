# https://leetcode.com/problems/best-time-to-buy-and-sell-stock

from core.problem_base import *

class MaxProfit(ProblemBase):
    def Solution(self, prices: list[int]) -> int:
        buyDay = 0
        profit = 0
        for i in range(1, len(prices)):
            if prices[buyDay] > prices[i]:
                buyDay = prices[i]
                buyDay = i
            else:
                temp = prices[i] - prices[buyDay]
                if temp > profit:
                    profit = temp

        return profit

if __name__ == '__main__':
    TestGen(MaxProfit) \
        .Add(lambda tc: tc.Param([7,1,5,3,6,4]).Result(5)) \
        .Add(lambda tc: tc.Param([7,6,4,3,1]).Result(0)) \
        .Run()
