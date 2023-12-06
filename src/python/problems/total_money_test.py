# https://leetcode.com/problems/calculate-money-in-leetcode-bank

from core.problem_base import *

class TotalMoney(ProblemBase):
    def Solution(self, n: int) -> int:
        week = 0
        result = 0
        for i in range(n):
            day = i % 7
            if day == 0:
                week += 1
            
            result += week + day

        return result

if __name__ == '__main__':
    TestGen(TotalMoney) \
        .Add(lambda tc: tc.Param(4).Result(10)) \
        .Add(lambda tc: tc.Param(10).Result(37)) \
        .Add(lambda tc: tc.Param(20).Result(96)) \
        .Run()
