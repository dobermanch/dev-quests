#https://leetcode.com/problems/counting-bits/
from core.problem_base import *

class CountBits(ProblemBase):
    def Solution(self, n: int) -> list[int]:
        result = [0] * (n + 1)

        for i in range(1, n + 1):
            result[i] = result[i & i - 1] + 1

        return result

if __name__ == '__main__':
    TestGen(CountBits) \
        .Add(lambda tc: tc.Param(2).Result([0,1,1])) \
        .Add(lambda tc: tc.Param(5).Result([0,1,1,2,1,2])) \
        .Run()

