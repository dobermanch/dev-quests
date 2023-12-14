# https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column

from core.problem_base import *

class OnesMinusZeros(ProblemBase):
    def Solution(self, grid: list[list[int]]) -> list[list[int]]:
        rows = len(grid)
        cols = len(grid[0])    
        rowMap = [0] * rows
        colMap = [0] * cols

        for row in range(rows):
            for col in range(cols):
                if grid[row][col] == 1:
                    rowMap[row] += 1
                    colMap[col] += 1

        result = [0] * rows
        for row in range(rows):
            result[row] = [0] * cols
            for col in range(cols):
                result[row][col] = rowMap[row] + colMap[col] - (rows - rowMap[row]) - (cols - colMap[col])

        return result

if __name__ == '__main__':
    TestGen(OnesMinusZeros) \
        .Add(lambda tc: tc.Param([[0,1,1],[1,0,1],[0,0,1]]).Result([[0,0,4],[0,0,4],[-2,-2,2]])) \
        .Add(lambda tc: tc.Param([[1,1,1],[1,1,1]]).Result([[5,5,5],[5,5,5]])) \
        .Run()
