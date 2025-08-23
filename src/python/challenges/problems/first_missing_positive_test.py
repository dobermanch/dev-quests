#https://leetcode.com/problems/first-missing-positive/
from core.problem_base import *

class FirstMissingPositive(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        length = len(nums)
        for i in range(length):
            while nums[i] > 0 and nums[i] <= length and nums[i] != nums[nums[i] - 1]:
                nums[nums[i] - 1], nums[i] = nums[i], nums[nums[i] - 1]
        
        for i in range(length):
            if nums[i] != i + 1:
                return i + 1

        return length + 1


if __name__ == '__main__':
    TestGen(FirstMissingPositive) \
        .Add(lambda tc: tc.Param([1,2,0]).Result(3)) \
        .Add(lambda tc: tc.Param([3,4,-1,1]).Result(2)) \
        .Add(lambda tc: tc.Param([7,8,9,11,12]).Result(1)) \
        .Run()
