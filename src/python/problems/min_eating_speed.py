#https://leetcode.com/problems/koko-eating-bananas/

import math
from core.problem_base import *

class MinEatingSpeed(ProblemBase):
    def Solution(self, piles: list[int], h: int) -> int:
        left = 1
        right = max(piles)

        while left < right:
            mid = (right + left) // 2
            count = 0
            for pile in piles:
                count += math.ceil(pile / mid)
            
            if count > h:
                left = mid + 1
            else:
                right = mid

        return left

if __name__ == '__main__':
    TestGen(MinEatingSpeed) \
        .Add(lambda tc: tc.Param("piles", [3,6,7,11]).Param("h", 8).Result(4)) \
        .Add(lambda tc: tc.Param("piles", [312884470]).Param("h", 312884469).Result(2)) \
        .Add(lambda tc: tc.Param("piles", [1000000000]).Param("h", 2).Result(500000000)) \
        .Add(lambda tc: tc.Param("piles", [805306368,805306368,805306368]).Param("h", 1000000000).Result(3)) \
        .Add(lambda tc: tc.Param("piles", [980628391,681530205,734313996,168632541]).Param("h", 819870953).Result(4)) \
        .Add(lambda tc: tc.Param("piles", [312884470]).Param("h", 968709470).Result(1)) \
        .Add(lambda tc: tc.Param("piles", [3,6,7,11,3,444,5,3,4,45,66]).Param("h", 15).Result(89)) \
        .Add(lambda tc: tc.Param("piles", [30,11,23,4,20]).Param("h", 12).Result(10)) \
        .Add(lambda tc: tc.Param("piles", [30,11,23,4,20]).Param("h", 5).Result(30)) \
        .Add(lambda tc: tc.Param("piles", [30,11,23,4,20]).Param("h", 6).Result(23)) \
        .Add(lambda tc: tc.Param("piles", [30]).Param("h", 1).Result(30)) \
        .Add(lambda tc: tc.Param("piles", [30]).Param("h", 2).Result(15)) \
        .Run()
