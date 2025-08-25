# https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii

from typing import List
from core.problem_base import *

class FindMinimumInRotatedSortedArrayIi(ProblemBase):
    def Solution(self, nums: List[int]) -> int:
        left = 0
        right = len(nums) - 1
        
        while left < right:
            mid = (left + right) // 2
            if nums[mid] > nums[right]:
                left = mid + 1
            elif nums[left] == nums[mid] and nums[mid] == nums[right]:
                right -= 1
            else:
                right = mid

        return nums[left]


if __name__ == '__main__':
    TestGen(FindMinimumInRotatedSortedArrayIi) \
        .Add(lambda tc: tc.Param([10,1,10,10,10]).Result(1)) \
        .Add(lambda tc: tc.Param([3,3,3,5,1,3,3]).Result(1)) \
        .Add(lambda tc: tc.Param([3,3,1,3]).Result(1)) \
        .Add(lambda tc: tc.Param([1,3,3]).Result(1)) \
        .Add(lambda tc: tc.Param([1,3,5]).Result(1)) \
        .Add(lambda tc: tc.Param([2,2,2,0,1]).Result(0)) \
        .Add(lambda tc: tc.Param([1,1,1,1,1,1,1,1,1,1,1,1,1]).Result(1)) \
        .Run()