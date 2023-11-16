#https://leetcode.com/problems/perfect-squares

from heapq import heappop, heappush
from core.problem_base import *

class NumSquares(ProblemBase):
    def Solution(self, n: int) -> int:
        map = [0] * (n + 1)

        for i in range(1, n + 1):
            map[i] = 2**31

            for j in range(1, i + 1):
                pow = j * j
                if i - pow < 0:
                    break

                map[i] = min(map[i], map[i - pow] + 1)

        return map[n]

if __name__ == '__main__':
    TestGen(NumSquares) \
        .Add(lambda tc: tc.Param("n", 1).Result(1)) \
        .Add(lambda tc: tc.Param("n", 13).Result(2)) \
        .Add(lambda tc: tc.Param("n", 4).Result(1)) \
        .Add(lambda tc: tc.Param("n", 3).Result(3)) \
        .Add(lambda tc: tc.Param("n", 12).Result(3)) \
        .Run()
