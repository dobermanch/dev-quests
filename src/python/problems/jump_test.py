#https://leetcode.com/problems/jump-game-ii/

from core.problem_base import *

class Jump(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        result = 0
        left = 0
        right = 0
        next = 0
        length = len(nums) - 1

        while right < length:
            if left <= right:
                next = max(left + nums[left], next)
                left += 1
            else:
                right = next
                result += 1

        return result

if __name__ == '__main__':
    TestGen(Jump) \
        .Add(lambda tc: tc.Param("nums", [2,3,1,1,4]).Result(2)) \
        .Add(lambda tc: tc.Param("nums", [2,3,0,1,4]).Result(2)) \
        .Run()
