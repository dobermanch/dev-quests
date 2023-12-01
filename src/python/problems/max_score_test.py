# https://leetcode.com/problems/maximum-subsequence-score

from heapq import heappop, heappush
from core.problem_base import *

class MaxScore(ProblemBase):
    def Solution(self, nums1: list[int], nums2: list[int], k: int) -> int:
        sum = 0
        result = 0
        queue = []
        map = sorted(list(zip(nums1, nums2)), key=lambda it: -it[1])
        for val1, val2 in map:
            heappush(queue, val1)
            sum += val1
            k -= 1
            if k <= 0:
                result = max(result, sum * val2)
                sum -= heappop(queue)

        return result

if __name__ == '__main__':
    TestGen(MaxScore) \
        .Add(lambda tc: tc.Param([1,3,3,2]).Param([2,1,3,4]).Param(3).Result(12)) \
        .Add(lambda tc: tc.Param([4,2,3,1,1]).Param([7,5,10,9,6]).Param(1).Result(30)) \
        .Run()
