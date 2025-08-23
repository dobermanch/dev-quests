# https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array

from core.problem_base import *

class MaxProduct2(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        num1 = 0
        num2 = 0
        for i in range(len(nums)):
            if nums[i] > num1:
                num2 = num1
                num1 = nums[i]
            elif nums[i] > num2:
                num2 = nums[i]

        return (num1 - 1) * (num2 - 1)

if __name__ == '__main__':
    TestGen(MaxProduct2) \
        .Add(lambda tc: tc.Param([2,1,231,1,123,23,23]).Result(28060)) \
        .Add(lambda tc: tc.Param([3,4,5,2]).Result(12)) \
        .Add(lambda tc: tc.Param([1,5,4,5]).Result(16)) \
        .Add(lambda tc: tc.Param([3,7]).Result("0")) \
        .Run()
