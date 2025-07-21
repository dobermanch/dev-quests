# https://leetcode.com/problems/plus-one

from core.problem_base import *

class PlusOne(ProblemBase):
    def Solution(self, digits: list[int]) -> list[int]:
        result = [1] * (len(digits) + 1)
        carry = 1
        for i in range(len(digits) - 1, -1, -1):
            temp = digits[i] + carry
            carry = temp // 10
            result[i + 1] = temp % 10

        return result if carry > 0 else result[1:]

if __name__ == '__main__':
    TestGen(PlusOne) \
        .Add(lambda tc: tc.Param([1,2,3]).Result([1,2,4])) \
        .Add(lambda tc: tc.Param([4,3,2,1]).Result([4,3,2,2])) \
        .Add(lambda tc: tc.Param([9]).Param([1,0])) \
        .Run()
