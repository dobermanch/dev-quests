# https://leetcode.com/problems/domino-and-tromino-tiling

from core.problem_base import *

class NumTilings(ProblemBase):
    def Solution(self, n: int) -> int:
        if n == 1:
           return 1

        mod = 10**9 + 7
        treeBack = 0
        twoBack = 1
        oneBack = 1
        result = 0
        for _ in range(n - 1):
            result = (oneBack * 2.0 + treeBack) % mod
            treeBack = twoBack
            twoBack = oneBack
            oneBack = result

        return int(result)

if __name__ == '__main__':
    TestGen(NumTilings) \
        .Add(lambda tc: tc.Param(1000).Result(979232805)) \
        .Add(lambda tc: tc.Param(7).Result(117)) \
        .Add(lambda tc: tc.Param(6).Result(53)) \
        .Add(lambda tc: tc.Param(5).Result(24)) \
        .Add(lambda tc: tc.Param(4).Result(11)) \
        .Add(lambda tc: tc.Param(3).Result(5)) \
        .Add(lambda tc: tc.Param(2).Result(2)) \
        .Add(lambda tc: tc.Param(1).Result(1)) \
        .Run()
