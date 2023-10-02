#https://leetcode.com/problems/find-the-highest-altitude

from core.problem_base import *

class LargestAltitude(ProblemBase):
    def Solution(self, gain: list[int]) -> int:
        result = 0
        current = 0
        for i in range(len(gain)):
            current += gain[i]
            if current > result:
                result = current

        return result
        

if __name__ == '__main__':
    TestGen(LargestAltitude) \
        .Add(lambda tc: tc.Param("gain", [-5,1,5,0,-7]).Result(1)) \
        .Add(lambda tc: tc.Param("gain", [-5,1,5,0,-7]).Result(0)) \
        .Run()
