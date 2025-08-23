#https://leetcode.com/problems/n-queens-ii

from collections import defaultdict
from core.problem_base import *

class TotalNQueens(ProblemBase):
    def Solution(self, n: int) -> list[list[str]]:
        def placeQueens(row, leftDiagMap, rightDiagMap, colMap) -> int:
            if row >= n:
                return 1

            result = 0
            for col in range(n):
                leftDiagShift = row + col
                rightDiagShift = n + (row - col)

                if (colMap & 1 << col) != 0 \
                    or (leftDiagMap & 1 << leftDiagShift) != 0 \
                    or (rightDiagMap & 1 << rightDiagShift) != 0:
                    continue

                colMap |= 1 << col
                leftDiagMap |= 1 << leftDiagShift
                rightDiagMap |= 1 << rightDiagShift

                result += placeQueens(row + 1, leftDiagMap, rightDiagMap, colMap)

                colMap &= ~(1 << col)
                leftDiagMap &= ~(1 << leftDiagShift)
                rightDiagMap &= ~(1 << rightDiagShift)

            return result

        return placeQueens(0, 0, 0, 0)


if __name__ == '__main__':
    TestGen(TotalNQueens) \
        .Add(lambda tc: tc.Param(4).Result(2)) \
        .Add(lambda tc: tc.Param(1).Result(1)) \
        .Add(lambda tc: tc.Param(2).Result(0)) \
        .Add(lambda tc: tc.Param(3).Result(0)) \
        .Add(lambda tc: tc.Param(9).Result(352)) \
        .Run()
