# https://leetcode.com/problems/maximum-product-difference-between-two-pairs

from core.problem_base import *

class MaxProductDifference(ProblemBase):
    def Solution1(self, nums: list[int]) -> int:
        min1 = min2 = 10**4
        max1 = 0
        max2 = 0

        for num in nums:
            if num > max1:
                max2 = max1
                max1 = num
            elif num > max2:
                max2 = num

            if num < min1:
                min2 = min1
                min1 = num
            elif num < min2:
                min2 = num

        return max1 * max2 - min1 * min2
    
    def Solution2(self, nums: list[int]) -> int:
        nums.sort()
        return (nums[-2] * nums[-1]) - (nums[0] * nums[1])

if __name__ == '__main__':
    TestGen(MaxProductDifference) \
        .Add(lambda tc: tc.Param([5,6,2,7,4]).Result(34)) \
        .Add(lambda tc: tc.Param([4,2,5,9,7,4,8]).Result(64)) \
        .Add(lambda tc: tc.Param([1,6,7,5,2,4,10,6,4]).Result(68)) \
        .Run()
