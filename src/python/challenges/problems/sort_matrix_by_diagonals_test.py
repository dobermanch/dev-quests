
# https://leetcode.com/problems/sort-matrix-by-diagonals

from typing import List
from core.problem_base import *

class SortMatrixByDiagonals(ProblemBase):
    def Solution(self, grid: List[List[int]]) -> List[List[int]]:
        n = len(grid)

        diagonals = [[] for _ in range(2 * n - 1)]

        for row in range(n):
            for col in range(n):
                diagonal = n + col - row - 1
                diagonals[diagonal].append(grid[row][col])

        for i in range(len(diagonals)):
            if i < n:
                diagonals[i].sort(reverse=True)
            else:
                diagonals[i].sort()

            for j in range(len(diagonals[i])):
                if i < n:
                    row = n - len(diagonals[i]) + j
                    col = j
                else:
                    row = j
                    col = n - len(diagonals[i]) + j
                grid[row][col] = diagonals[i][j]

        return grid

if __name__ == '__main__':
    TestGen(SortMatrixByDiagonals) \
        .Add(lambda tc: tc.Param([[1,7,3,5],[9,8,2,2],[4,5,6,8],[4,2,8,7]]).Result([[8,2,2,5],[9,7,7,3],[4,8,6,8],[4,2,5,1]]) ) \
        .Add(lambda tc: tc.Param([[1,7,3],[9,8,2],[4,5,6]]).Result([[8,2,3],[9,6,7],[4,5,1]]) ) \
        .Add(lambda tc: tc.Param([[0,1],[1,2]]).Result([[2,1],[1,0]]) ) \
        .Run()
