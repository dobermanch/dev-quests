
# https://leetcode.com/problems/valid-triangle-number

from typing import List
from core.problem_base import *

class ValidTriangleNumber(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        nums.sort()
        count = 0

        for c in range(len(nums) - 1, 1, -1):
            a = 0
            b = c - 1
            while a < b:
                if nums[a] + nums[b] > nums[c]:
                    count += b - a
                    b -= 1
                else:
                    a += 1

        return count

if __name__ == '__main__':
    TestGen(ValidTriangleNumber) \
        .Add(lambda tc: tc.Param([2,2,3,4]).Result(3)) \
        .Add(lambda tc: tc.Param([4,2,3,4]).Result(4)) \
        .Run()

# Test cases
# [2,2,3,4]
# [4,2,3,4]
