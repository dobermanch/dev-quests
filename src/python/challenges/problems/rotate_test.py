# https://leetcode.com/problems/rotate-array

from core.problem_base import *

class Rotate(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> list[int]:
        """
        Do not return anything, modify nums in-place instead.
        """
        index = 0
        prev = nums[index]
        visited = 0
        count = 0
        length = len(nums)
        while count < length:
            count += 1
            index += k
            if index >= length:
                index %= length

            (nums[index], prev) = (prev, nums[index])

            if index == visited and index < length - 1:
                visited += 1
                index += 1
                prev = nums[index]

        return nums

if __name__ == '__main__':
    TestGen(Rotate) \
        .Add(lambda tc: tc.Param([1,2,3,4,5,6,7]).Param(3).Result([5,6,7,1,2,3,4])) \
        .Add(lambda tc: tc.Param([-1,-100,3,99]).Param(2).Result([3,99,-1,-100])) \
        .Run()
