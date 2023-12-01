# https://leetcode.com/problems/find-peak-element

from core.problem_base import *

class FindPeakElement(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        length = len(nums) - 1
        left = 0
        right = length
        while left <= right:
            mid = (left + right) // 2
            if mid < length and nums[mid] < nums[mid + 1]:
                left = mid + 1
            elif mid > 0 and nums[mid - 1] > nums[mid]:
                right = mid - 1
            else:
                return mid

        return 0


if __name__ == '__main__':
    TestGen(FindPeakElement) \
        .Add(lambda tc: tc.Param([1,2,3,1]).Result(2)) \
        .Add(lambda tc: tc.Param([1,2,1,3,5,6,4]).Result(5)) \
        .Run()
