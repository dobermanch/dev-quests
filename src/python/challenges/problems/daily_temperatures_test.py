#https://leetcode.com/problems/jump-game/

from core.problem_base import *

class DailyTemperatures(ProblemBase):
    def Solution(self, temperatures: list[int]) -> list[int]:
        result = [0] * len(temperatures)
        stack = []

        for i in range(len(temperatures) - 1, -1, -1):
            while stack:
                if temperatures[stack[-1]] > temperatures[i]:
                    result[i] = stack[-1] - i
                    break
                stack.pop()

            stack.append(i)

        return result

if __name__ == '__main__':
    TestGen(DailyTemperatures) \
        .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
        .Add(lambda tc: tc.Param([30,40,50,60]).Result([1,1,1,0])) \
        .Add(lambda tc: tc.Param([30,60,90]).Result([1,1,0])) \
        .Run()
