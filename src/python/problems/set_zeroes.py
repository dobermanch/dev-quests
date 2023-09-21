#https://leetcode.com/problems/set-matrix-zeroes/
class SetZeroes:
    def Solution(self, matrix: list[list[int]]) -> None:
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



SetZeroes().Solution([[1,2,3,4],[5,0,7,8],[0,10,11,12],[13,14,15,0]])
