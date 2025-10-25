
# https://leetcode.com/problems/move-zeroes

from typing import List
from core.problem_base import *

class MoveZeroes(ProblemBase):
    def Solution(self, nums: List[int]) -> List[int]:
        left = 0
        for right in range(len(nums)):
            if nums[right] == 0:
                continue

            nums[left] = nums[right]

            if left != right:
                nums[right] = 0

            left += 1

        return nums

if __name__ == '__main__':
    TestGen(MoveZeroes) \
        .Add(lambda tc: tc.Param([0,1,0,3,12]).Result([1,3,12,0,0])) \
        .Add(lambda tc: tc.Param([0]).Result([0])) \
        .Run()

