# https://leetcode.com/problems/summary-ranges

from core.problem_base import *

class SummaryRanges(ProblemBase):
    def Solution(self, nums: list[int]) -> list[str]:
        result = []
        startAt = 0
        length = len(nums)
        for i in range(length):
            if i == length - 1 or nums[i] + 1 < nums[i + 1]:
                if i == startAt:
                    result.append(f"{nums[startAt]}")
                else:
                    result.append(f"{nums[startAt]}->{nums[i]}")

                startAt = i + 1

        return result

if __name__ == '__main__':
    TestGen(SummaryRanges) \
        .Add(lambda tc: tc.Param([0,2,3,4,6,8,9]).Result(["0","2->4","6","8->9"])) \
        .Add(lambda tc: tc.Param([0,1,2,4,5,7]).Result(["0->2","4->5","7"])) \
        .Run()
