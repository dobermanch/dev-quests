# https://leetcode.com/problems/path-crossing/

from core.problem_base import *

class IsPathCrossing(ProblemBase):
    def Solution(self, path: str) -> bool:
        point = (0, 0)

        visited = set()
        visited.add(point)

        for direction in path:
            if direction == 'N':
                point = (point[0], point[1] + 1)
            elif direction == 'S':
                point = (point[0], point[1] - 1)
            elif direction == 'E':
                point = (point[0] + 1, point[1])
            elif direction == 'W':
                point = (point[0] - 1, point[1])

            if point in visited:
                return True
            visited.add(point)

        return False

if __name__ == '__main__':
    TestGen(IsPathCrossing) \
        .Add(lambda tc: tc.Param("NES").Result(False)) \
        .Add(lambda tc: tc.Param("NESWW").Result(True)) \
        .Run()
