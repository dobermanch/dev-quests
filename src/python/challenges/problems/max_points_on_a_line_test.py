
# https://leetcode.com/problems/max-points-on-a-line

from cmath import inf
from typing import List
from core.problem_base import *

class MaxPointsOnALine(ProblemBase):
    def Solution1(self, points: List[List[int]]) -> int:
        if len(points) <= 2:
            return len(points)

        maxPoints = 1
        for i in range(len(points)):
            slopes = {}
            for j in range(i + 1, len(points)):
                x1, y1 = points[i]
                x2, y2 = points[j]

                slope = inf
                if x1 - x2 != 0:
                    slope = (y1 - y2) / (x1 - x2)

                slopes[slope] = slopes.get(slope, 0) + 1

                maxPoints = max(slopes[slope], maxPoints)
    
        return maxPoints + 1

    def Solution2(self, points: List[List[int]]) -> int:
        maxPoints = 1

        lines = []

        for i in range(len(points)):
            for j in range(i + 1, len(points)):
                lines.append([points[i], points[j]])

        for _, point in enumerate(points):
            for _, line in enumerate(lines):
                if point == line[0] or point == line[1]:
                    continue

                x1, y1 = line[0][0], line[0][1]
                x2, y2 = line[-1][0], line[-1][1]
                area = x1*(y2 - point[1]) + x2*(point[1] - y1) + point[0]*(y1 - y2)
                if area == 0:
                    line.append(point)
                    maxPoints = max(maxPoints, len(line))

        return maxPoints

if __name__ == '__main__':
    TestGen(MaxPointsOnALine) \
        .Add(lambda tc: tc.Param([[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]).Result(4) ) \
        .Add(lambda tc: tc.Param([[1,1],[2,2],[3,3]]).Result(3) ) \
        .Run()
