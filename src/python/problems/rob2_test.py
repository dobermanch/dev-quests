#https://leetcode.com/problems/house-robber-ii/
from core.problem_base import *

class Rob2(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        if len(nums) == 1:
            return nums[0]

        def RobHouses(start, end):
            rob1 = 0
            rob2 = 0

            for i in range(start, end):
                temp = max(rob1 + nums[i], rob2)
                rob1 = rob2
                rob2 = temp
            return rob2

        return max(RobHouses(0, len(nums) - 1), RobHouses(1, len(nums)))


if __name__ == '__main__':
    TestGen(Rob2) \
        .Add(lambda tc: tc.Param([2,3,2]).Result(3)) \
        .Add(lambda tc: tc.Param([1,2,3,1]).Result(4)) \
        .Add(lambda tc: tc.Param([1,2,3]).Result(3)) \
        .Run()
