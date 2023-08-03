#https://leetcode.com/problems/two-sum/

from core.ProblemBase import *

class TwoSum(ProblemBase):
    def Solution(self, nums: List[int], target: int) -> List[int]:
        map = {}

        for i in range(len(nums)):
            if target - nums[i] in map:
                return [map[target - nums[i]], i]
            map[nums[i]] = i
            
        return []

        
if __name__ == '__main__':
    TestGen(TwoSum) \
        .Add(lambda tc: tc.Param("nums", [2,7,11,15]).Param("target", 9).Result([0,1])) \
        .Add(lambda tc: tc.Param("nums", [3,2,4]).Param("target", 6).Result([1,2])) \
        .Add(lambda tc: tc.Param("nums", [3,3]).Param("target", 6).Result([0,1])) \
        .Run()
