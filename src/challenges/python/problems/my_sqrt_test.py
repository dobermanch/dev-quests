# https://leetcode.com/problems/sqrtx

from core.problem_base import *

class MySqrt(ProblemBase):
    def Solution(self, x: int) -> int:
        left = 0
        right = x
        while left <= right:
            root = (left + right) // 2
            target = root * root

            if target == x:
                return root
            elif target < x:
                left = root + 1
            else:
                right = root - 1

        return right

if __name__ == '__main__':
    TestGen(MySqrt) \
        .Add(lambda tc: tc.Param(4).Result(2)) \
        .Add(lambda tc: tc.Param(8).Result(2)) \
        .Add(lambda tc: tc.Param(13284790).Result(3644)) \
        .Add(lambda tc: tc.Param(0).Result(0)) \
        .Add(lambda tc: tc.Param(1).Result(1)) \
        .Add(lambda tc: tc.Param(2).Result(1)) \
        .Run()
