# https://leetcode.com/problems/contains-duplicate-ii

from core.problem_base import *

class ContainsNearbyDuplicate(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> bool:
        map = {}
        for i, num in enumerate(nums):
            if num in map and i - map[num] <= k:
                return True
            
            map[nums[i]] = i

        return False

if __name__ == '__main__':
    TestGen(ContainsNearbyDuplicate) \
        .Add(lambda tc: tc.Param([1,2,3,1]).Param(3).Result(True)) \
        .Add(lambda tc: tc.Param([1,0,1,1]).Param(1).Result(True)) \
        .Add(lambda tc: tc.Param([1,2,3,1,2,3]).Param(2).Result(False)) \
        .Run()
