# https://leetcode.com/problems/largest-odd-number-in-string

from core.problem_base import *

class LargestOddNumber(ProblemBase):
    def Solution(self, num: str) -> str:
        for i in range(len(num) - 1, -1, -1):
            if int(num[i]) % 2 != 0:
                return num[:(i + 1)]

        return ""

if __name__ == '__main__':
    TestGen(LargestOddNumber) \
        .Add(lambda tc: tc.Param("52").Result("5")) \
        .Add(lambda tc: tc.Param("4206").Result("")) \
        .Add(lambda tc: tc.Param("35427").Result("35427")) \
        .Run()
