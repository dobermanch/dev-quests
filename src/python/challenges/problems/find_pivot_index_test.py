
# https://leetcode.com/problems/find-pivot-index

from typing import List
from core.problem_base import *

class FindPivotIndex(ProblemBase):
    def Solution(self, nums: List[int]) -> int:
        sum1 = 0
        for i in range(len(nums) - 1, -1, -1):
            sum1 += nums[i]

        sum2 = 0
        for i in range(len(nums)):
            sum2 += nums[i]

            if sum1 == sum2:
                return i

            sum1 -= nums[i]

        return -1

if __name__ == '__main__':
    TestGen(FindPivotIndex) \
        .Add(lambda tc: tc.Param([1,7,3,6,5,6]).Return(3)) \
        .Add(lambda tc: tc.Param([1,2,3]).Return(-1)) \
        .Add(lambda tc: tc.Param([2,1,-1]).Return(0)) \
        .Run()
