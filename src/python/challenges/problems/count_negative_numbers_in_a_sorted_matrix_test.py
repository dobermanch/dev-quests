# https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix

from typing import List
from core.problem_base import *

class CountNegativeNumbersInASortedMatrix(ProblemBase):
    def Solution(self, grid: List[List[int]]) -> int:
        result = 0
        height = len(grid)
        width = len(grid[0])

        for row in range(height):
            for col in range(width - 1, -1, -1):
                if grid[row][col] < 0:
                    result += height - row
                    width = col
                else:
                    width = col + 1
                    break

        return result

if __name__ == '__main__':
    TestGen(CountNegativeNumbersInASortedMatrix) \
        .Add(lambda tc: tc.Param([[3,2],[-3,-3],[-3,-3],[-3,-3]]).Result(6)) \
        .Add(lambda tc: tc.Param([[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]).Result(8)) \
        .Add(lambda tc: tc.Param([[3,2],[1,0]]).Result(0)) \
        .Run()