
# https://leetcode.com/problems/min-cost-climbing-stairs

from typing import List
from core.problem_base import *

class MinCostClimbingStairs(ProblemBase):
    def Solution(self, cost: List[int]) -> int:
        cost = cost + [0]
        for i in range(2, len(cost)):
            cost[i] += min(cost[i - 1], cost[i - 2])

        return cost[-1]

if __name__ == '__main__':
    TestGen(MinCostClimbingStairs) \
        .Add(lambda tc: tc.Param([10,15,20]).Result(15)) \
        .Add(lambda tc: tc.Param([1,100,1,1,1,100,1,1,100,1]).Result(6)) \
        .Run()

