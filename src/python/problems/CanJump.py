#https://leetcode.com/problems/jump-game/

from core.ProblemBase import *

class CanJump(ProblemBase):
    def Solution(self, nums: list[int]) -> bool:
        jumpTo = len(nums) - 1
        for i in range(len(nums) - 1, -1, -1):
            if i + nums[i] >= jumpTo:
                jumpTo = i

        return jumpTo == 0

if __name__ == '__main__':
    TestGen(CanJump) \
        .Add(lambda tc: tc.Param("nums", [2,3,1,1,4]).Result(True)) \
        .Add(lambda tc: tc.Param("nums", [3,2,1,0,4]).Result(False)) \
        .Run()
