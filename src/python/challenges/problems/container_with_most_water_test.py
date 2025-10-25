
# https://leetcode.com/problems/container-with-most-water

from typing import List
from core.problem_base import *

class ContainerWithMostWater(ProblemBase):
    def Solution(self, height: List[int]) -> int:
        capacity = 0
        left = 0
        right = len(height) - 1

        while left < right:
            min_height = min(height[left], height[right])
            capacity = max(capacity, min_height * (right - left))

            if height[left] > height[right]:
                right -= 1
            else:
                left += 1

        return capacity

if __name__ == '__main__':
    TestGen(ContainerWithMostWater) \
        .Add(lambda tc: tc.Param([1,8,6,2,5,4,8,3,7]).Result(49)) \
        .Add(lambda tc: tc.Param([1,1]).Result(1)) \
        .Run()
