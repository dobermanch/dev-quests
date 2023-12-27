# https://leetcode.com/problems/minimum-time-to-make-rope-colorful

from core.problem_base import *

class MinCost(ProblemBase):
    def Solution(self, colors: str, neededTime: list[int]) -> int:
        result = 0
        maxCost = neededTime[0]
        for i  in range(1, len(colors)):
            if colors[i] == colors[i - 1]:
                result += min(neededTime[i], maxCost)
                maxCost = max(neededTime[i], maxCost)
            else:
                maxCost = neededTime[i]

        return result

if __name__ == '__main__':
    TestGen(MinCost) \
        .Add(lambda tc: tc.Param("abaac").Param([1,2,3,4,5]).Result(3)) \
        .Add(lambda tc: tc.Param("abc").Param([1,2,3]).Result(0)) \
        .Add(lambda tc: tc.Param("aabaa").Param([1,2,3,4,1]).Result(2)) \
        .Add(lambda tc: tc.Param("bbbaaa").Param([4,9,3,8,8,9]).Result(23)) \
        .Run()
