# https://leetcode.com/problems/minimum-path-sum

from heapq import heappop, heappush
from core.problem_base import *

class MinPathSum(ProblemBase):
    def Solution(self, grid: list[list[int]]) -> int:
        height = len(grid)
        width = len(grid[0])

        for row in range(height):
            for col in range(width):
                if row == 0 and col == 0:
                    continue

                left = grid[row][col] + grid[row][col - 1] if col > 0 else 1000
                top =  grid[row][col] + grid[row - 1][col] if row > 0 else 1000

                grid[row][col] = min(left, top)

        return grid[-1][-1]

if __name__ == '__main__':
    TestGen(MinPathSum) \
        .Add(lambda tc: tc.Param("grid", [[1,3,1],[1,5,1],[4,2,1]]).Result(7)) \
        .Add(lambda tc: tc.Param("grid", [[1,2,3],[4,5,6]]).Result(12)) \
        .Run()
