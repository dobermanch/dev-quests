# https://leetcode.com/problems/minimum-time-visiting-all-points

from core.problem_base import *

class MinTimeToVisitAllPoints(ProblemBase):
    def Solution(self, points: list[list[int]]) -> int:
        result = 0
        for i in range(len(points) - 1):
            result += max(
                abs(points[i][0] - points[i + 1][0]), 
                abs(points[i][1] - points[i + 1][1]))

        return result

if __name__ == '__main__':
    TestGen(MinTimeToVisitAllPoints) \
        .Add(lambda tc: tc.Param([[1,1],[3,4],[-1,0]]).Result(7)) \
        .Add(lambda tc: tc.Param([[3,2],[-2,2]]).Result(5)) \
        .Run()
