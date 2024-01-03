# https://leetcode.com/problems/number-of-laser-beams-in-a-bank

from core.problem_base import *

class NumberOfBeams(ProblemBase):
    def Solution(self, bank: list[str]) -> int:
        result = 0
        prevDevices = 0
        for floor  in bank:
            devices = 0
            for i in range(len(floor )):
                if floor[i] == '1':
                    devices += 1

            if devices > 0:
                result += devices * prevDevices
                prevDevices = devices

        return result

if __name__ == '__main__':
    TestGen(NumberOfBeams) \
        .Add(lambda tc: tc.Param(["011001","000000","010100","001000"]).Result(8)) \
        .Add(lambda tc: tc.Param(["000","111","000"]).Result(0)) \
        .Run()
