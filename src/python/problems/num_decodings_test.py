#https://leetcode.com/problems/decode-ways/
from core.problem_base import *

class NumDecodings(ProblemBase):
    def Solution(self, s: str) -> int:
        n = len(s)
        temp1 = 1
        temp2 = 1
        for i in range(n - 1, -1, -1):
            temp = temp1
            if s[i] == '0':
                temp1 = 0
            elif i + 1 < n and (s[i] == '1' or s[i] == '2' and s[i + 1] <= '6'):
                temp1 += temp2

            temp2 = temp

        return temp1


if __name__ == '__main__':
    TestGen(NumDecodings) \
        .Add(lambda tc: tc.Param("12").Result(2)) \
        .Add(lambda tc: tc.Param("226").Result(3)) \
        .Add(lambda tc: tc.Param("06").Result(0)) \
        .Run()
