#https://leetcode.com/problems/find-the-duplicate-number

import math
from core.ProblemBase import *

class FindDuplicate(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        slow = nums[0]
        fast = nums[0]

        while True:
            slow = nums[slow]
            fast = nums[nums[fast]]
            if slow == fast:
                break

        fast = nums[0]
        while slow != fast:
            slow = nums[slow]
            fast = nums[fast]

        return slow
    
    def Solution1(self, nums: list[int]) -> int:
        result = nums[0]

        for i in range(len(nums)):
            index = abs(nums[i])
            if nums[index] < 0:
                result = index
                break
            nums[index] *= -1

        for i in range(len(nums)):
            nums[i] = abs(nums[i])
            
        return result
    
    def Solution2(self, nums: list[int]) -> int:
        map = set()     
        for i in range(len(nums)):
            if nums[i] in map:
                return nums[i]

            map.add(nums[i])
        
        return 0

if __name__ == '__main__':
    TestGen(FindDuplicate) \
        .Add(lambda tc: tc.Param("nums", [1,3,4,2,2]).Result(2)) \
        .Add(lambda tc: tc.Param("nums", [3,1,3,4,2]).Result(3)) \
        .Run()
