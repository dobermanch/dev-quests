#https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/

from core.problem_base import *

class LongestSubarray(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        count = 0
        left = 0
        for right in range(len(nums)):
            if nums[right] == 0:
                count += 1            

            if count > 1:
                if nums[left] == 0:
                    count -= 1

                left += 1

        return len(nums) - left - 1

if __name__ == '__main__':
    TestGen(LongestSubarray) \
        .Add(lambda tc: tc.Param("nums", [1,1,0,1]).Result(3)) \
        .Add(lambda tc: tc.Param("nums", [0,1,1,1,0,1,1,0,1]).Result(5)) \
        .Add(lambda tc: tc.Param("nums", [1,1,1]).Result(2)) \
        .Run()
