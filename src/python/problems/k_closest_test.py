#https://leetcode.com/problems/k-closest-points-to-origin/
from heapq import heappush, heappop

class KClosest:
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

KClosest().Solution("tree")
