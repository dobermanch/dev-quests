#https://leetcode.com/problems/maximum-product-subarray
from core.problem_base import *

class MaxProduct(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        result = nums[0]
        maxProd = 1
        minProd = 1
        for num in nums:
            prod1 = num * maxProd
            prod2 = num * minProd

            maxProd = max(num, prod1, prod2)
            minProd = min(num, prod1, prod2)

            result = max(result, maxProd)

        return result


if __name__ == '__main__':
    TestGen(MaxProduct) \
        .Add(lambda tc: tc.Param([2,3,-2,4]).Result(6)) \
        .Add(lambda tc: tc.Param([-2,0,-1]).Result(0)) \
        .Run()
