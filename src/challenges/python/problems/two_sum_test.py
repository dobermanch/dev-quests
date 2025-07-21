#https://leetcode.com/problems/two-sum/

from core.problem_base import *

class TwoSum(ProblemBase):
    def Solution(self, nums: list[int], target: int) -> list[int]:
        map = {}

        for i in range(len(nums)):
            if target - nums[i] in map:
                return [map[target - nums[i]], i]
            map[nums[i]] = i
            
        return []

        
if __name__ == '__main__':
    TestGen(TwoSum) \
        .Add(lambda tc: tc.Param([2,7,11,15]).Param(9).Result([0,1])) \
        .Add(lambda tc: tc.Param([3,2,4]).Param(6).Result([1,2])) \
        .Add(lambda tc: tc.Param([3,3]).Param(6).Result([0,1])) \
        .Run()
