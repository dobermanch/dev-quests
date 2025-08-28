# https://leetcode.com/problems/non-overlapping-intervals/
from core.problem_base import *

class EraseOverlapIntervals(ProblemBase):
    def Solution(self, intervals: list[list[int]]) -> int:
        result = 0
        intervals.sort(key = lambda x: x[0])
        current = intervals[0]
        for i in range(1, len(intervals)):
            if current[1] > intervals[i][0]:
                result += 1
                current = current if current[1] <= intervals[i][1] else intervals[i]
            else:
                current = intervals[i]

        return result


if __name__ == '__main__':
    TestGen(EraseOverlapIntervals) \
        .Add(lambda tc: tc.Param([[1,2],[2,3],[3,4],[1,3]]).Result(1)) \
        .Add(lambda tc: tc.Param([[1,2],[1,2],[1,2]]).Result(2)) \
        .Add(lambda tc: tc.Param([[1,2],[2,3]]).Result(0)) \
        .Run()
