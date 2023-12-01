# https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
from core.problem_base import *

class FindMin(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        left = 0
        right = len(nums) - 1
        
        while left < right:
            mid = (left + right) // 2
            if nums[right] < nums[mid]:
                left = mid + 1
            else:
                right = mid

        return nums[left]


if __name__ == '__main__':
    TestGen(FindMin) \
        .Add(lambda tc: tc.Param([3,4,5,1,2]).Result(1)) \
        .Add(lambda tc: tc.Param([4,5,6,7,0,1,2]).Result(0)) \
        .Add(lambda tc: tc.Param([11,13,15,17]).Result(11)) \
        .Run()
