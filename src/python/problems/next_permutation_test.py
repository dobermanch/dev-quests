#https://leetcode.com/problems/next-permutation/

from core.problem_base import *

class NextPermutation(ProblemBase):
    def Solution(self, nums: list[int]) -> list[int]:
        """
        Do not return anything, modify nums in-place instead.
        """
        right = len(nums) - 1
        left = right - 1
        found = False

        while left >= 0:
            if not found and nums[left] < nums[right]:
                found = True
                right = len(nums) - 1
            elif not found:
                left -= 1
                right -= 1
            else:
                if nums[left] < nums[right]:
                    nums[left], nums[right] = nums[right], nums[left]
                    break
                right -= 1

        nums[left + 1:] = reversed(nums[left + 1:])


if __name__ == '__main__':
    TestGen(NextPermutation) \
        .Add(lambda tc: tc.Param("nums", [1,2,3]).Result([1,3,2])) \
        .Add(lambda tc: tc.Param("nums", [3,2,1]).Result([1,5,1])) \
        .Add(lambda tc: tc.Param("nums", [1,1,5]).Result([1,5,1])) \
        .Add(lambda tc: tc.Param("nums", [1,3,2]).Result([2,1,3])) \
        .Run()
