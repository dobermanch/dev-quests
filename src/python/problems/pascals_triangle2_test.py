# https://leetcode.com/problems/pascals-triangle-ii/
from core.problem_base import *

class PascalsTriangle2(ProblemBase):
    def Solution(self, rowIndex: int) -> list[int]:
        result = [1 for i in range(rowIndex + 1)]

        for i in range(2, rowIndex + 1):
            prev = result[0]
            for j in range(1, i):
                temp = result[j]
                result[j] = prev + result[j]
                prev = temp

        return result

if __name__ == '__main__':
    TestGen(PascalsTriangle2) \
        .Add(lambda tc: tc.Param(3).Result([1,3,3,1])) \
        .Add(lambda tc: tc.Param(0).Result([1])) \
        .Add(lambda tc: tc.Param(1).Result([1,1])) \
        .Run()
