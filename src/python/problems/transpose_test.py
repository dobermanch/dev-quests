# https://leetcode.com/problems/transpose-matrix

from core.problem_base import *

class Transpose(ProblemBase):
    def Solution(self, matrix: list[list[int]]) -> list[list[int]]:
        columns = len(matrix[0])
        rows = len(matrix)
        result = [0] * columns

        for col in range(columns):
            result[col] = [0] * rows
            for row in range(rows):
                result[col][row] = matrix[row][col]

        return result

if __name__ == '__main__':
    TestGen(Transpose) \
        .Add(lambda tc: tc.Param([[1,2,3],[4,5,6],[7,8,9]]).Result([[1,4,7],[2,5,8],[3,6,9]])) \
        .Add(lambda tc: tc.Param([[1,2,3],[4,5,6]]).Result([[1,4],[2,5],[3,6]])) \
        .Run()
