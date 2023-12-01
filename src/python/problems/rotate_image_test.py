# https://leetcode.com/problems/rotate-image/
from core.problem_base import *

class RotateImage(ProblemBase):
    def Solution(self, matrix: list[list[int]]) -> list[list[int]]:
        rows = len(matrix)
        cols = len(matrix[0])

        xL, xR = 0, cols - 1
        yT, yB = 0, rows - 1
        while xL < xR:
            x = xL
            y = yT
            while x < xR:
                temp = matrix[y][x]
                x1, y1 = x, y
                for _ in range(4):
                    if y1 == yT:
                        y1 = x1
                        x1 = xR
                    elif y1 == yB:
                        y1 = x1
                        x1 = xL
                    elif x1 == xR:
                        x1 = cols - 1 - y1
                        y1 = yB
                    elif x1 == xL:
                        x1 = cols - 1 - y1
                        y1 = yT

                    matrix[y1][x1], temp = temp, matrix[y1][x1]
                x += 1
            xL += 1
            xR -= 1
            yT += 1
            yB -= 1
        
        return matrix

if __name__ == '__main__':
    TestGen(RotateImage) \
        .Add(lambda tc: tc.Param([[1,2,3],[4,5,6],[7,8,9]]).Result([[7,4,1],[8,5,2],[9,6,3]])) \
        .Add(lambda tc: tc.Param([[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]).Result([[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]])) \
        .Run()
