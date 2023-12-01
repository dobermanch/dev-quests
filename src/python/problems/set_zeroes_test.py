#https://leetcode.com/problems/set-matrix-zeroes/
from core.problem_base import *

class SetZeroes(ProblemBase):
    def Solution(self, matrix: list[list[int]]) -> list[list[int]]:
        """
        Do not return anything, modify matrix in-place instead.
        """
        rows = len(matrix)
        cols = len(matrix[0])
        x0 = False

        for y in range(rows):
            if matrix[y][0] == 0:
                x0 = True

            for x in range(1, cols):
                if matrix[y][x] == 0:
                    matrix[0][x] = 0
                    matrix[y][0] = 0

        for y in range(rows - 1, -1, -1):
            for x in range(cols - 1, 0, -1):
                if matrix[0][x] == 0 or matrix[y][0] == 0:
                    matrix[y][x] = 0
            
            if x0:
                matrix[y][0] = 0
        
        return matrix

if __name__ == '__main__':
    TestGen(SetZeroes) \
        .Add(lambda tc: tc.Param([[1,1,1],[1,0,1],[1,1,1]]).Result([[1,0,1],[0,0,0],[1,0,1]])) \
        .Add(lambda tc: tc.Param([[0,1,2,0],[3,4,5,2],[1,3,1,5]]).Result([[0,0,0,0],[0,4,5,0],[0,3,1,0]])) \
        .Run()
