#https://leetcode.com/problems/k-closest-points-to-origin/
from heapq import heappush, heappop
from core.problem_base import *

class KClosest(ProblemBase):
    def Solution(self, points: list[list[int]], k: int) -> list[list[int]]:
        queue = []
        for point in points:
            heappush(queue, (point[0]**2 + point[1]**2, point))

        result = []
        while queue and k > 0:
            k -= 1
            _, point = heappop(queue)
            result.append(point)

        return result

if __name__ == '__main__':
    TestGen(KClosest) \
        .Add(lambda tc: tc.Param([[1,3],[-2,2]]).Param(1).Result([[-2,2]])) \
        .Add(lambda tc: tc.Param([[3,3],[5,-1],[-2,4]]).Param(2).Result([[3,3],[-2,4]])) \
        .Run()
