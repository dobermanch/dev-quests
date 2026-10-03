
# https://leetcode.com/problems/insert-interval

from typing import List
from core.problem_base import *

class InsertInterval(ProblemBase):
    def Solution(self, intervals: list[list[int]], newInterval: list[int]) -> list[list[int]]:
        result = []
        n = len(intervals)
        index = 0
        inteval = newInterval
        while index < n and intervals[index][1] < inteval[0]:
            result.append(intervals[index])
            index += 1

        while index < n and inteval[1] >= intervals[index][0]:
            inteval[0] = min(intervals[index][0], inteval[0])
            inteval[1] = max(intervals[index][1], inteval[1])
            index += 1

        result.append(inteval)
        result += intervals[index:]

        return result

if __name__ == '__main__':
    TestGen(InsertInterval) \
        .Add(lambda tc: tc.Param([[1,3],[6,9]]).Param([2,5]).Result([[1,5],[6,9]]) ) \
        .Add(lambda tc: tc.Param([[1,2],[3,5],[6,7],[8,10],[12,16]]).Param([4,8]).Result([[1,2],[3,10],[12,16]]) ) \
        .Run()

# Test cases
# [[1,3],[6,9]] | [2,5]
# [[1,2],[3,5],[6,7],[8,10],[12,16]] | [4,8]
