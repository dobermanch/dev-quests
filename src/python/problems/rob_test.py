#https://leetcode.com/problems/house-robber/
from core.problem_base import *

class Rob(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        rob1 = 0
        rob2 = 0

        for num in nums:
            temp = max(rob1 + num, rob2)
            rob1 = rob2
            rob2 = temp
        return rob2


if __name__ == '__main__':
    TestGen(Rob) \
        .Add(lambda tc: tc.Param([1,2,3,1]).Result(4)) \
        .Add(lambda tc: tc.Param([2,7,9,3,1]).Result(12)) \
        .Run()