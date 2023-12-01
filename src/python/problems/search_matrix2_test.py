# https://leetcode.com/problems/search-a-2d-matrix-ii/
from core.problem_base import *

class SearchMatrix2(ProblemBase):
    def Solution(self, matrix: list[list[int]], target: int) -> bool:
        row = 0
        col = len(matrix[0]) - 1

        while row < len(matrix) and col >= 0:
            if matrix[row][col] == target:
                return True

            if matrix[row][col] > target:
                col -= 1
            else:
                row += 1

        return False


if __name__ == '__main__':
    TestGen(SearchMatrix2) \
        .Add(lambda tc: tc.Param([[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]).Param(5).Result(True)) \
        .Add(lambda tc: tc.Param([[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]).Param(20).Result(False)) \
        .Run()
