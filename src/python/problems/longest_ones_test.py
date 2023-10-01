# https://leetcode.com/problems/max-consecutive-ones-iii/

from core.problem_base import *

class LongestOnes(ProblemBase):
    def Solution2(self, nums: list[int], k: int) -> int:
        left = 0
        right = 0
        for right in range(len(nums)):
            if nums[right] == 0:
                k -= 1

            if k < 0:
                if nums[left] == 0:
                    k += 1
                left += 1
        
        return right - left + 1
    
    def Solution1(self, nums: list[int], k: int) -> int:
        result = 0
        left = 0
        right = 0
        while right < len(nums):
            if nums[right] == 1:
                right += 1
            elif k > 0:
                k -= 1
                right += 1
            else:
                if nums[left] == 0:
                    k += 1
                left += 1

            result = max(result, right - left)
        
        return result

if __name__ == '__main__':
    TestGen(LongestOnes) \
        .Add(lambda tc: tc.Param("nums", [1,1,1,0,0,0,1,1,1,1,0]).Param("k", 2).Result(6)) \
        .Add(lambda tc: tc.Param("nums", [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1]).Param("k", 3).Result(10)) \
        .Run()
