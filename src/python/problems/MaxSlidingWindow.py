#https://leetcode.com/problems/sliding-window-maximum/
from heapq import heappush, heappop
class MaxSlidingWindow:
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


MaxSlidingWindow().Solution([9,10,9,-7,-4,-8,2,-6], 5)
