
# https://leetcode.com/problems/product-of-array-except-self

from typing import List
from core.problem_base import *

class ProductOfArrayExceptSelf(ProblemBase):
    def Solution(self, nums: List[int]) -> List[int]:
        n = len(nums)
        left = [1] * (n + 1)
        right = [1] * (n + 1)

        for i in range(n):
            left[i + 1] = left[i] * nums[i]
            right[n - i - 1] = right[n - i] * nums[n - i - 1]

        for i in range(n):
            nums[i] = left[i] * right[i + 1]

        return nums

if __name__ == '__main__':
    TestGen(ProductOfArrayExceptSelf) \
        .Add(lambda tc: tc.Param([-1,1,0,-3,3]).Result([0,0,9,0,0])) \
        .Add(lambda tc: tc.Param([1,2,3,4]).Result([24,12,8,6])) \
        .Run()
