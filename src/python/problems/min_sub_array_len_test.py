# https://leetcode.com/problems/minimum-size-subarray-sum

from core.problem_base import *

class MinSubArrayLen(ProblemBase):
    def Solution(self, target: int, nums: list[int]) -> int:
        result = 10**5
        left = 0
        right = 0
        sum = 0
        while right < len(nums) or sum >= target:
            if sum >= target:
                result = min(result, right - left)
                sum -= nums[left]
                left += 1
            else:
                sum += nums[right]
                right += 1

        return result if result != 10**5 else 0

if __name__ == '__main__':
    TestGen(MinSubArrayLen) \
        .Add(lambda tc: tc.Param(7).Param([2,3,1,2,4,3]).Result(2)) \
        .Add(lambda tc: tc.Param(4).Param([1,4,4]).Result(1)) \
        .Add(lambda tc: tc.Param(11).Param([1,1,1,1,1,1,1,1]).Result(0)) \
        .Run()
