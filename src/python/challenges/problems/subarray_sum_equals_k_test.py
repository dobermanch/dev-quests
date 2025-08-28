#https://leetcode.com/problems/subarray-sum-equals-k/
from core.problem_base import *

class SubarraySum(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> int:
        map = {}
        map[0] = 1
        result = 0
        sum = 0
        for i, num in enumerate(nums):
            sum += num

            if sum - k in map:
                result += map[sum - k]

            map[sum] = map.get(sum, 0) + 1

        return result

if __name__ == '__main__':
    TestGen(SubarraySum) \
        .Add(lambda tc: tc.Param([1,1,1]).Param(2).Result(2)) \
        .Add(lambda tc: tc.Param([1,2,3]).Param(3).Result(2)) \
        .Run()
