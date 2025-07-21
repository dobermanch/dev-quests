#https://leetcode.com/problems/missing-number/
from core.problem_base import *

class MissingNumber(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        result = len(nums)

        for i in range(len(nums)):
            result += i - nums[i]

        return result

    def Solution1(self, nums: list[int]) -> int:
        n = len(nums)
        result = n * (n + 1) // 2

        for num in nums:
            result -= num

        return result


if __name__ == '__main__':
    TestGen(MissingNumber) \
        .Add(lambda tc: tc.Param([3,0,1]).Result(2)) \
        .Add(lambda tc: tc.Param([0,1]).Result(2)) \
        .Add(lambda tc: tc.Param([9,6,4,2,3,5,7,0,1]).Result(8)) \
        .Run()
