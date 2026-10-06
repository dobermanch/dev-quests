
# https://leetcode.com/problems/find-k-closest-elements

import heapq
from typing import List
from core.problem_base import *

class FindKClosestElements(ProblemBase):
    def Solution(self, arr: List[int], k: int, x: int) -> List[int]:
        heap = []

        for num in arr:
            dist = abs(num - x)

            if len(heap) < k:
                heapq.heappush(heap, (-dist, num))
            elif dist < -heap[0][0]:
                heapq.heappop(heap)
                heapq.heappush(heap, (-dist, num))

        return sorted([num for _, num in heap])

if __name__ == '__main__':
    TestGen(FindKClosestElements) \
        .Add(lambda tc: tc.Param([1,2,3,4,5]).Param(4).Param(3).Result([1,2,3,4])) \
        .Add(lambda tc: tc.Param([1,1,2,3,4,5]).Param(4).Param(-1).Result([1,1,2,3])) \
        .Run()

# Test cases
# [1,2,3,4,5] | 4 | 3
# [1,1,2,3,4,5] | 4 | -1
