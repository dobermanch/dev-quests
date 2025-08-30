
# https://leetcode.com/problems/unique-paths-ii

from typing import List
from core.problem_base import *

class UniquePathsIi(ProblemBase):
    def Solution(self, obstacleGrid: List[List[int]]) -> int:
        width = len(obstacleGrid)
        height = len(obstacleGrid[0])

        for row in range(width):
            for col in range(height):
                if obstacleGrid[row][col] == 1:
                    obstacleGrid[row][col] = 0
                    continue

                if row == 0 and col == 0:
                    obstacleGrid[row][col] = 1
                    continue

                if row - 1 >= 0:
                    obstacleGrid[row][col] += obstacleGrid[row - 1][col]

                if col - 1 >= 0:
                    obstacleGrid[row][col] += obstacleGrid[row][col - 1]

        return obstacleGrid[width - 1][height - 1]

if __name__ == '__main__':
    TestGen(UniquePathsIi) \
        .Add(lambda tc: tc.Param([[0,0,0,0],[0,1,0,0],[0,0,1,0],[1,1,0,0],[0,0,0,0],[0,0,0,0]]).Result(2) ) \
        .Add(lambda tc: tc.Param([[0,0,0,0],[0,1,0,0],[0,0,0,0],[0,0,0,0]]).Result(8) ) \
        .Add(lambda tc: tc.Param([[0,1],[0,0]]).Result(1) ) \
        .Add(lambda tc: tc.Param([[0,0,0],[0,1,0],[0,0,0]]).Result(2) ) \
        .Run()
