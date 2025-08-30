
# https://leetcode.com/problems/find-k-pairs-with-smallest-sums

from heapq import heappush, heappop
from typing import List
from core.problem_base import *

class FindKPairsWithSmallestSums(ProblemBase):
    def Solution(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        m = len(nums1)
        n = len(nums2)

        result = []
        visited = set()

        heap = [(nums1[0] + nums2[0], (0, 0))]
        visited.add((0, 0))

        while k > 0 and heap:
            _, (i, j) = heappop(heap)
            result.append([nums1[i], nums2[j]])

            if i + 1 < m and (i + 1, j) not in visited:
                heappush(heap, (nums1[i + 1] + nums2[j], (i + 1, j)))
                visited.add((i + 1, j))

            if j + 1 < n and (i, j + 1) not in visited:
                heappush(heap, (nums1[i] + nums2[j + 1], (i, j + 1)))
                visited.add((i, j + 1))
            k -= 1

        return result

if __name__ == '__main__':
    TestGen(FindKPairsWithSmallestSums) \
        .Add(lambda tc: tc.Param([1,7,11]).Param([2,4,6]).Param(9).Result([[1,2],[1,4],[1,6]]) ) \
        .Add(lambda tc: tc.Param([1,2,3,4,5]).Param([1,2,3,4,5,6]).Param(20).Result([[1,1],[1,2],[2,1],[1,3],[2,2],[3,1],[1,4],[2,3],[3,2],[4,1],[1,5],[2,4],[3,3],[4,2],[5,1],[1,6],[2,5],[3,4],[4,3],[5,2]]) ) \
        .Add(lambda tc: tc.Param([1,1,2]).Param([1,2,3]).Param(2).Result([[1,1],[1,1]]) ) \
        .Run()
