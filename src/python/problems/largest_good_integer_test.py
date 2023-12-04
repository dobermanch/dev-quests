# https://leetcode.com/problems/largest-3-same-digit-number-in-string

from core.problem_base import *

class LargestGoodInteger(ProblemBase):
    def Solution(self, num: str) -> str:
        result = ''
        digit = num[0]
        count = 1
        for i in range(1, len(num)):
            if num[i] != digit:
                digit = num[i]
                count = 1
                continue
            
            count += 1
            if count >= 3 and digit > result:
                result = digit

        return str(result * 3)

if __name__ == '__main__':
    TestGen(LargestGoodInteger) \
        .Add(lambda tc: tc.Param("6777133339").Result("777")) \
        .Add(lambda tc: tc.Param("2300019").Result("000")) \
        .Add(lambda tc: tc.Param("42352338").Result("")) \
        .Run()
