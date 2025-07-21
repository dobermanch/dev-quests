# https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii

from core.problem_base import *

class RemoveDuplicates2(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        left = 1
        count = 1
        for right in range(1, len(nums)):
            count = count + 1 if nums[right] == nums[right - 1] else 1

            if count <= 2:
                nums[left] = nums[right]
                left += 1
            
        return left

if __name__ == '__main__':
    TestGen(RemoveDuplicates2) \
        .Add(lambda tc: tc.Param([0,0,1,1,1,1,2,3,3]).Result(7)) \
        .Add(lambda tc: tc.Param([1,1,1,2,2,3]).Result(5)) \
        .Run()
