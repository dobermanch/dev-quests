# https://leetcode.com/problems/special-positions-in-a-binary-matrix

from core.problem_base import *

class NumSpecial(ProblemBase):
    def Solution(self, mat: list[list[int]]) -> int:
        rows = len(mat)
        cols = len(mat[0])
        rowMap = [0] * rows
        colMap = [0] * cols
        result = 0

        for row in range(rows):
            for col in range(cols):
                if mat[row][col] == 1:
                    rowMap[row] += 1
                    colMap[col] += 1

        for row in range(rows):
            if rowMap[row] != 1:
                continue

            for col in range(cols):
                if mat[row][col] == 1 and colMap[col] == 1:
                    result += 1

        return result

if __name__ == '__main__':
    TestGen(NumSpecial) \
        .Add(lambda tc: tc.Param([[0,0,0,0,0,1,0,0],[0,0,0,0,1,0,0,1],[0,0,0,0,1,0,0,0],[1,0,0,0,1,0,0,0],[0,0,1,1,0,0,0,0]]).Result(1)) \
        .Add(lambda tc: tc.Param([[1,0,0],[0,0,1],[1,0,0]]).Result(1)) \
        .Add(lambda tc: tc.Param([[1,0,0],[0,1,0],[0,0,1]]).Result(3)) \
        .Add(lambda tc: tc.Param([[0,0,0,0,0],[1,0,0,0,0],[0,1,0,0,0],[0,0,1,0,0],[0,0,0,1,1]]).Result(3)) \
        .Add(lambda tc: tc.Param([[0,0,1,0],[0,0,0,0],[0,0,0,0],[0,1,0,0]]).Result(2)) \
        .Run()
