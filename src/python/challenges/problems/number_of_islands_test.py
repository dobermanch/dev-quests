
# https://leetcode.com/problems/number-of-islands

from typing import List
from core.problem_base import *

class NumberOfIslands(ProblemBase):
    def Solution(self, grid: List[List[str]]) -> int:
        ROWS = len(grid)
        COLS = len(grid[0])

        def search(row, col):
            if (col < 0 or col >= COLS
             or row < 0 or row >= ROWS
             or grid[row][col] == "0"):
                return

            grid[row][col] = "0"

            search(row + 1, col)
            search(row - 1, col)
            search(row, col + 1)
            search(row, col - 1)

        count = 0
        for row in range(ROWS):
            for col in range(COLS):
                if grid[row][col] == "1":
                    search(row, col)
                    count += 1

        return count

if __name__ == '__main__':
    TestGen(NumberOfIslands) \
        .Add(lambda tc: tc.Param([["1","1","1","1","0"],["1","1","0","1","0"],["1","1","0","0","0"],["0","0","0","0","0"]]).Result(1)) \
        .Add(lambda tc: tc.Param([["1","1","0","0","0"],["1","1","0","0","0"],["0","0","1","0","0"],["0","0","0","1","1"]]).Result(3)) \
        .Run()

# Test cases
# [["1","1","1","1","0"],["1","1","0","1","0"],["1","1","0","0","0"],["0","0","0","0","0"]]
# [["1","1","0","0","0"],["1","1","0","0","0"],["0","0","1","0","0"],["0","0","0","1","1"]]
