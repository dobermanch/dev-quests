
# https://leetcode.com/problems/factorial-trailing-zeroes

from math import floor
from typing import List
from core.problem_base import *

class FactorialTrailingZeroes(ProblemBase):
    def Solution(self, n: int) -> int:
        if n <= 4:
            return 0

        count = 0
        power = 1
        while power < n:
            power *= 5
            count += n // power

        return count


if __name__ == '__main__':
    TestGen(FactorialTrailingZeroes) \
        .Add(lambda tc: tc.Param(23).Result(4)) \
        .Add(lambda tc: tc.Param(5).Result(1)) \
        .Add(lambda tc: tc.Param(3).Result(0)) \
        .Add(lambda tc: tc.Param(0).Result(0)) \
        .Run()
