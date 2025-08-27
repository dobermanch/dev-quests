
# https://leetcode.com/problems/bitwise-and-of-numbers-range

from typing import List
from core.problem_base import *

class BitwiseAndOfNumbersRange(ProblemBase):
    def Solution(self, left: int, right: int) -> int:

        while right > left:
            right &= (right - 1)

        return left & right

        shift = 0
        while left and right:
            if left == right:
                return left

            left &= ~(1 << shift)
            right &= ~(1 << shift)
            shift += 1

        return 0

if __name__ == '__main__':
    TestGen(BitwiseAndOfNumbersRange) \
        .Add(lambda tc: tc.Param(1).Param(1).Result(1)) \
        .Add(lambda tc: tc.Param(416).Param(436).Result(416)) \
        .Add(lambda tc: tc.Param(5).Param(7).Result(4)) \
        .Add(lambda tc: tc.Param(0).Param(0).Result(0)) \
        .Add(lambda tc: tc.Param(1).Param(2147483647).Result(0)) \
        .Run()
