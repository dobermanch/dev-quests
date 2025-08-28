#https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons

from core.problem_base import *

class FindMinArrowShots(ProblemBase):
    def Solution(self, points: list[list[int]]) -> int:
        points.sort(key=lambda x: (x[1], x[1]))

        result = 1
        end = points[0][1]
        for point in points:
            if end < point[0]:
                end = point[1]
                result += 1

        return result

if __name__ == '__main__':
    TestGen(FindMinArrowShots) \
        .Add(lambda tc: tc.Param([[10,16],[2,8],[1,6],[7,12]]).Result(2)) \
        .Add(lambda tc: tc.Param([[1,2],[3,4],[5,6],[7,8]]).Result(4)) \
        .Add(lambda tc: tc.Param([[1,2],[2,3],[3,4],[4,5]]).Result(2)) \
        .Run()
