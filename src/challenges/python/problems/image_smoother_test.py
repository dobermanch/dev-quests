# https://leetcode.com/problems/image-smoother

from core.problem_base import *

class ImageSmoother(ProblemBase):
    def Solution(self, img: list[list[int]]) -> list[list[int]]:
        directions = [ 
            [ -1, -1 ], [ -1, 0 ], [ -1, 1 ], 
            [  0, -1 ], [  0, 0 ], [  0, 1 ], 
            [  1, -1 ], [  1, 0 ], [  1, 1 ] 
        ]

        count = len(directions)
        rows = len(img)
        cols = len(img[0])
        result = [0] * rows

        for row in range(rows):
            result[row] = [0] * cols
            for col in range(cols):
                neighbors = 0

                for i in range(count):
                    y = row + directions[i][0]
                    x = col + directions[i][1]

                    if y >= 0 and y < rows and x >= 0 and x < cols:
                        result[row][col] += img[y][x]
                        neighbors += 1

                result[row][col] //= neighbors

        return result

if __name__ == '__main__':
    TestGen(ImageSmoother) \
        .Add(lambda tc: tc.Param([[100,200,100],[200,50,200],[100,200,100]]).Result([[137,141,137],[141,138,141],[137,141,137]])) \
        .Add(lambda tc: tc.Param([[1,1,1],[1,0,1],[1,1,1]]).Result([[0,0,0],[0,0,0],[0,0,0]])) \
        .Run()
