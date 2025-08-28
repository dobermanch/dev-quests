#https://leetcode.com/problems/longest-increasing-subsequence/
from core.problem_base import *

class LengthOfLIS(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        map = [0] * len(nums)
        for i in range(len(nums) - 1, -1, -1):
            for j in range(i + 1, len(nums)):
                if nums[i] < nums[j]:
                    map[i] = max(map[i], map[j])
            map[i] += 1

        return max(map)
    
    def Solution1(self, nums: list[int]) -> int:
        sub = [nums[0]]
        for i in range(1, len(nums)):
            if nums[i] > sub[-1]:
                sub.append(nums[i])
                continue

            for j in range(len(sub)):
                if nums[i] <= sub[j]:
                    sub[j] = nums[i]
                    break

        return len(sub)

if __name__ == '__main__':
    TestGen(LengthOfLIS) \
        .Add(lambda tc: tc.Param([10,9,2,5,3,7,101,18]).Result(4)) \
        .Add(lambda tc: tc.Param([0,1,0,3,2,3]).Result(4)) \
        .Add(lambda tc: tc.Param([7,7,7,7,7,7,7]).Result(1)) \
        .Run()
