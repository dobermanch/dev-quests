
# https://leetcode.com/problems/rotting-oranges

from collections import deque
from typing import List
from core.problem_base import *

class RottingOranges(ProblemBase):
    def Solution(self, grid: list[list[int]]) -> int:
        ROWS = len(grid)
        COLS = len(grid[0])
        directions = [(0,1), (0,-1), (1,0), (-1,0)]

        rotten = deque()
        fresh = 0
        for row in range(ROWS):
            for col in range(COLS):
                if grid[row][col] == 2:
                    rotten.append((row, col))
                elif grid[row][col] == 1:
                    fresh += 1

        result = 0
        while rotten and fresh > 0:
            result += 1

            for _ in range(len(rotten)):
                r, c = rotten.popleft()

                for dr, dc in directions:
                    nr = r + dr
                    nc = c + dc

                    if 0 <= nr < ROWS and 0 <= nc < COLS and grid[nr][nc] == 1:
                        grid[nr][nc] = 2
                        fresh -= 1
                        rotten.append((nr, nc))

        return result if fresh == 0 else -1

if __name__ == '__main__':
    TestGen(RottingOranges) \
        .Add(lambda tc: tc.Param([[2,1,1],[1,1,0],[0,1,1]]).Result(4)) \
        .Add(lambda tc: tc.Param([[2,1,1],[0,1,1],[1,0,1]]).Result(-1)) \
        .Add(lambda tc: tc.Param([[0,2]]).Result(0)) \
        .Run()

# Test cases
# [[2,1,1],[1,1,0],[0,1,1]]
# [[2,1,1],[0,1,1],[1,0,1]]
# [[0,2]]
