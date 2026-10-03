
# https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k

from typing import List
from core.problem_base import *

class MaximumSumOfDistinctSubarraysWithLengthK(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> int:
        map = set()

        result = float('-inf')
        left = 0
        accum = 0
        for right in range(len(nums)):
            while nums[right] in map:
                map.remove(nums[left])
                accum -= nums[left]
                left += 1

            map.add(nums[right])
            accum += nums[right]

            if right - left + 1 == k:
                result = max(result, accum)
                accum -= nums[left]
                map.remove(nums[left])
                left += 1

        return 0 if result == float('-inf') else result

if __name__ == '__main__':
    TestGen(MaximumSumOfDistinctSubarraysWithLengthK) \
        .Add(lambda tc: tc.Param([4,2,4,5,6]).Param(4).Result(17)) \
        .Add(lambda tc: tc.Param([1,5,4,2,9,9,9]).Param(3).Result(15)) \
        .Add(lambda tc: tc.Param([4,4,4]).Param(3).Result(0)) \
        .Run()

# Test cases
# [1,5,4,2,9,9,9] | 3
# [4,4,4] | 3
