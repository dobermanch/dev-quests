#https://leetcode.com/problems/guess-number-higher-or-lower

from core.problem_base import *

class GuessNumber(ProblemBase):
    def Solution(self, n: int, pick: int) -> int:
        def guess(n):
            return -1 if n > pick else 1 if n < pick else 0

        left = 0
        right = n
        num = 0
        while left <= right:
            num = left + (right - left) // 2
            result = guess(num)
            if result == 0:
                break
            elif result == 1:
                left = num + 1
            else:
                right = num - 1

        return num

if __name__ == '__main__':
    TestGen(GuessNumber) \
        .Add(lambda tc: tc.Param(10).Param(6).Result(6)) \
        .Add(lambda tc: tc.Param(1).Param(1).Result(1)) \
        .Add(lambda tc: tc.Param(2).Param(1).Result(1)) \
        .Run()
