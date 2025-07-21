# https://leetcode.com/problems/gas-station

from core.problem_base import *

class CanCompleteCircuit(ProblemBase):
    def Solution(self, gas: list[int], cost: list[int]) -> int:
        startAt = 0
        sum = 0
        total = 0
        for i in range(len(gas)):
            total += gas[i] - cost[i]
            sum += gas[i] - cost[i]

            if sum < 0:
                sum = 0
                startAt = i + 1
            
        return startAt if total >= 0 else -1

if __name__ == '__main__':
    TestGen(CanCompleteCircuit) \
        .Add(lambda tc: tc.Param([1,2,3,4,5]).Param([3,4,5,1,2]).Result(3)) \
        .Add(lambda tc: tc.Param([2,3,4]).Param([3,4,3]).Result(-1)) \
        .Add(lambda tc: tc.Param([1,2,3,4,5,5,70]).Param([1,2,3,4,5,5,70]).Result(6)) \
        .Add(lambda tc: tc.Param([2]).Param([2]).Result(0)) \
        .Run()
