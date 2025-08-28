# https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points

from core.problem_base import *

class MaxWidthOfVerticalArea(ProblemBase):
    def Solution(self, points: list[list[int]]) -> int:
        points.sort(key=lambda x: x[0])

        max_diff = 0
        for i in range(1, len(points)):
            max_diff = max(max_diff, points[i][0] - points[i - 1][0])

        return max_diff

if __name__ == '__main__':
    TestGen(MaxWidthOfVerticalArea) \
        .Add(lambda tc: tc.Param([[8,7],[9,9],[7,4],[9,7]]).Result(1)) \
        .Add(lambda tc: tc.Param([[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]).Result(3)) \
        .Run()
