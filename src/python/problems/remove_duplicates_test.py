# https://leetcode.com/problems/remove-duplicates-from-sorted-array

from core.problem_base import *

class RemoveDuplicates(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        left = 1
        for right in range(1, len(nums)):
            if nums[right] != nums[right - 1]:
                nums[left] = nums[right]
                left += 1 

        return left

if __name__ == '__main__':
    TestGen(RemoveDuplicates) \
        .Add(lambda tc: tc.Param([1,1,2]).Result(2)) \
        .Add(lambda tc: tc.Param([0,0,1,1,1,2,2,3,3,4]).Result(5)) \
        .Run()
