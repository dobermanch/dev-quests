# https://leetcode.com/problems/h-index

from core.problem_base import *

class HIndex(ProblemBase):
    def Solution(self, citations: list[int]) -> int:
        citations.sort()
        length = len(citations)

        for i in range(length):
            if citations[i] < length - i:
                continue

            for hIndex in range(citations[i], -1, -1):
                if hIndex <= length - i:
                    return hIndex

        return 0

if __name__ == '__main__':
    TestGen(HIndex) \
        .Add(lambda tc: tc.Param([3, 1, 7, 8, 9]).Result(3)) \
        .Add(lambda tc: tc.Param([3,0,6,1,5]).Result(3)) \
        .Add(lambda tc: tc.Param([1,3,1]).Result(1)) \
        .Add(lambda tc: tc.Param([100]).Result(1)) \
        .Run()
