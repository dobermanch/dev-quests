# https://leetcode.com/problems/reverse-integer/

from core.problem_base import *

class Reverse(ProblemBase):
    def Solution(self, x: int) -> int:
        negative = -1 if x < 0 else 1

        result = 0
        num = x * negative
        while num != 0:
            result = result * 10 + num % 10
            num = num // 10
        
        result = result * negative

        if result > (2 ** 31) - 1 or result < -(2 ** 31):
            return 0

        return result

        
if __name__ == '__main__':
    TestGen(Reverse) \
        .Add(lambda tc: tc.Param("x", 123).Result(321)) \
        .Add(lambda tc: tc.Param("x", -123).Result(-321)) \
        .Add(lambda tc: tc.Param("x", 120).Result(21)) \
        .Add(lambda tc: tc.Param("x", 1534236469).Result(0)) \
        .Add(lambda tc: tc.Param("x", -1534236469).Result(0)) \
        .Run()
