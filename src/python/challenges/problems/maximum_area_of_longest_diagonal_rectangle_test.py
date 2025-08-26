
# https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle

from cmath import sqrt
import heapq
from typing import List
from core.problem_base import *

class MaximumAreaOfLongestDiagonalRectangle(ProblemBase):
    def Solution(self, dimensions: List[List[int]]) -> int:
        maxDiagonal = 0
        maxArea = 0

        for row in range(len(dimensions)):
            diagonal = math.sqrt(dimensions[row][0] ** 2 + dimensions[row][1] ** 2)
            area = dimensions[row][0] * dimensions[row][1]

            if diagonal > maxDiagonal:
                maxDiagonal = diagonal
                maxArea = area
            elif diagonal == maxDiagonal:
                maxArea = max(maxArea, area)

        return maxArea

    def Solution(self, dimensions: List[List[int]]) -> int:
        diagonals = []

        for row in range(len(dimensions)):
            diagonal = sqrt(dimensions[row][0] ** 2 + dimensions[row][1] ** 2)
            diagonals.append((-diagonal, row))

        heapq.heapify(diagonals)

        diagonal, row = heapq.heappop(diagonals)
        result = dimensions[row][0] * dimensions[row][1]
        while diagonals:
            nextDiagonal, nextRow = heapq.heappop(diagonals)
            if diagonal == nextDiagonal:
                result = max(result, dimensions[nextRow][0] * dimensions[nextRow][1])
            else:
                break

        return result

if __name__ == '__main__':
    TestGen(MaximumAreaOfLongestDiagonalRectangle) \
        .Add(lambda tc: tc.Param([[9,3],[8,6]]).Result(48) ) \
        .Add(lambda tc: tc.Param([[3,4],[4,3]]).Result(12) ) \
        .Run()
