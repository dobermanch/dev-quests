#https://leetcode.com/problems/car-fleet/

from heapq import heappop, heappush
from core.ProblemBase import *

class CarFleet(ProblemBase):
    def Solution(self, target: int, position: List[int], speed: List[int]) -> int:
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
        .Add(lambda tc: tc.Param("target", 12).Param("position", [10,8,0,5,3]).Param("speed", [2,4,1,1,3]).Result(3)) \
        .Add(lambda tc: tc.Param("target", 10).Param("position", [3]).Param("speed", [3]).Result(1)) \
        .Add(lambda tc: tc.Param("target", 100).Param("position", [0,2,4]).Param("speed", [0,2,4]).Result(1)) \
        .Add(lambda tc: tc.Param("target", 10).Param("position", [6,8]).Param("speed", [3,2]).Result(2)) \
        .Add(lambda tc: tc.Param("target", 0).Param("position", [0]).Param("speed", [1]).Result(1)) \
        .Run()
