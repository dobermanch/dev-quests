# https://leetcode.com/problems/buy-two-chocolates

from core.problem_base import *

class BuyChoco(ProblemBase):
    def Solution1(self, prices: list[int], money: int) -> int:
        result = -200
        cost = 0
        for price in prices:
            result = max(result, cost - price)
            cost = max(cost, money - price)

        return money if result < 0 else result

    def Solution2(self, prices: list[int], money: int) -> int:
        prices.sort()

        cost = prices[0] + prices[1]
        return money if cost > money else money - cost

if __name__ == '__main__':
    TestGen(BuyChoco) \
        .Add(lambda tc: tc.Param([1,2,2]).Param(3).Result(0)) \
        .Add(lambda tc: tc.Param([3,2,3]).Param(3).Result(3)) \
        .Add(lambda tc: tc.Param([74,31,38,24,25,24,5]).Param(79).Result(50)) \
        .Run()
