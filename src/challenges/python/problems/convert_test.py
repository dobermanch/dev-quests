# https://leetcode.com/problems/zigzag-conversion

from core.problem_base import *

class Convert(ProblemBase):
    def Solution(self, s: str, numRows: int) -> str:
        if numRows == 1:
            return s

        builders = [""] * numRows

        count = 0
        direction = 1
        for i in range(len(s)):
            builders[count] += s[i]

            if count == 0:
                direction = 1
            elif count == numRows - 1:
                direction = -1

            count += direction

        return "".join(builders)

if __name__ == '__main__':
    TestGen(Convert) \
        .Add(lambda tc: tc.Param("PAYPALISHIRING").Param(3).Result("PAHNAPLSIIGYIR")) \
        .Add(lambda tc: tc.Param("PAYPALISHIRING").Param(4).Result("PINALSIGYAHRPI")) \
        .Add(lambda tc: tc.Param("A").Param(1).Result("A")) \
        .Add(lambda tc: tc.Param("AR").Param(1).Result("AR")) \
        .Run()
