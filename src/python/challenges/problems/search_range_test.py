# https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array

from core.problem_base import *

class SearchRange(ProblemBase):
    def Solution(self, nums: list[int], target: int) -> list[int]:
        def search(nums, target, searchLeft):
            left = 0
            right = len(nums) - 1
            index = -1
            while left <= right:
                mid = (left + right) // 2
                if nums[mid] < target:
                    left = mid + 1
                elif nums[mid] > target:
                    right = mid - 1
                else:
                    index = mid
                    if searchLeft:
                        right = mid - 1
                    else:
                        left = mid + 1

            return index

        return [
            search(nums, target, True), 
            search(nums, target, False)
        ]

if __name__ == '__main__':
    TestGen(SearchRange) \
        .Add(lambda tc: tc.Param([5,7,7,8,8,10]).Param(8).Result([3,4])) \
        .Add(lambda tc: tc.Param([5,7,7,8,8,10]).Param(6).Result([-1,-1])) \
        .Add(lambda tc: tc.Param([]).Param(0).Result([-1,-1])) \
        .Run()
