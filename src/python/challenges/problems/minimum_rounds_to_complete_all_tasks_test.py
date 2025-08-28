# https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks

from core.problem_base import *

class MinimumRounds(ProblemBase):
    def Solution(self, tasks: list[int]) -> int:
        map = {}

        for i in range(len(tasks)):
            map[tasks[i]] = map.get(tasks[i], 0) + 1

        result = 0
        for value in map.values():
            if value == 1:
                return -1

            result += value // 3 + (0 if value % 3 == 0 else 1)

        return result

if __name__ == '__main__':
    TestGen(MinimumRounds) \
        .Add(lambda tc: tc.Param([2,3,3,2,2,4,2,3,4]).Result(4)) \
        .Add(lambda tc: tc.Param([2,1,2,2,3,3]).Result(-1)) \
        .Run()
