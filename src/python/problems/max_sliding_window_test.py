#https://leetcode.com/problems/sliding-window-maximum/
from heapq import heappush, heappop
from core.problem_base import *

class MaxSlidingWindow(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> list[int]:
        queue = []
        result = []

        for i in range(len(nums)):
            while queue and i - k >= queue[0][1]:
                heappop(queue)
            
            heappush(queue, (-nums[i], i))

            if i >= k - 1:
                result.append(nums[queue[0][1]])

        return result

if __name__ == '__main__':
    TestGen(MaxSlidingWindow) \
        .Add(lambda tc: tc.Param([1,3,-1,-3,5,3,6,7]).Param(3).Result([3,3,5,5,6,7])) \
        .Add(lambda tc: tc.Param([1]).Param(1).Result([1])) \
        .Run()
