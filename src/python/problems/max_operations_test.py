# https://leetcode.com/problems/max-number-of-k-sum-pairs/

from core.problem_base import *

class MaxOperations(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> int:
        result = 0

        nums.sort()
        left = 0
        right = len(nums) - 1
        while left < right:
            sum = nums[left] + nums[right]
            if sum == k:
                left += 1
                right -= 1
                result += 1
            elif sum > k:
                right -= 1
            else:
                left += 1

        return result


if __name__ == '__main__':
    TestGen(MaxOperations) \
        .Add(lambda tc: tc.Param([1,2,3,4]).Param(5).Result(2)) \
        .Add(lambda tc: tc.Param([3,1,3,4,3]).Param(6).Result(1)) \
        .Run()
