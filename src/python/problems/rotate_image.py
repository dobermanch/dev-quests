# https://leetcode.com/problems/rotate-image/

class RotateImage:
    def Solution(self, matrix: list[list[int]]) -> None:
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

RotateImage().Solution([[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]])
