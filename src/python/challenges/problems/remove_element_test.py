# https://leetcode.com/problems/remove-element

from core.problem_base import *

class RemoveElement(ProblemBase):
    def Solution(self, nums: list[int], val: int) -> int:
        left = 0
        for right in range(len(nums)):
            if nums[right] != val:
                nums[left] = nums[right]
                left += 1 

        return (left, nums[:left])

if __name__ == '__main__':
    TestGen(RemoveElement) \
        .Add(lambda tc: tc.Param([0,1,2,2,3,0,4,2]).Param(2).Result((5, [0,1,3,0,4]))) \
        .Add(lambda tc: tc.Param([3,2,2,3]).Param(3).Result((2, [2,2]))) \
        .Run()
