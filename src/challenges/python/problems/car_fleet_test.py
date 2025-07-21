#https://leetcode.com/problems/car-fleet/

from heapq import heappop, heappush
from core.problem_base import *

class CarFleet(ProblemBase):
    def Solution(self, target: int, position: list[int], speed: list[int]) -> int:
        queue = []
        for i in range(len(position)):
            time = (target - position[i]) / speed[i]
            heappush(queue, (-position[i], time))

        result = 0
        previousTime = -1
        while queue:
            _, time = heappop(queue)
            if time > previousTime:
                previousTime = time
                result += 1

        return result

if __name__ == '__main__':
    TestGen(CarFleet) \
        .Add(lambda tc: tc.Param(12).Param([10,8,0,5,3]).Param([2,4,1,1,3]).Result(3)) \
        .Add(lambda tc: tc.Param(10).Param([3]).Param([3]).Result(1)) \
        .Add(lambda tc: tc.Param(100).Param([0,2,4]).Param([4,2,1]).Result(1)) \
        .Add(lambda tc: tc.Param(10).Param([6,8]).Param([3,2]).Result(2)) \
        .Run()
