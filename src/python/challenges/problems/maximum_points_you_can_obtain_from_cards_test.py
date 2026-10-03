
# https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards

from typing import List
from core.problem_base import *

class MaximumPointsYouCanObtainFromCards(ProblemBase):
    def Solution(self, cardPoints: list[int], k: int) -> int:
        result = 0
        total = sum(cardPoints)
        n = len(cardPoints)
        window = n - k
        if window == 0:
            return total

        accum = 0

        left = 0
        for right in range(n):
            accum += cardPoints[right]

            if right - left + 1 >= window:
                result = max(result, total - accum)
                accum -= cardPoints[left]
                left += 1

        return result

if __name__ == '__main__':
    TestGen(MaximumPointsYouCanObtainFromCards) \
        .Add(lambda tc: tc.Param([1,2,3,4,5,6,1]).Param(3).Result(12)) \
        .Add(lambda tc: tc.Param([2,2,2]).Param(2).Result(4)) \
        .Add(lambda tc: tc.Param([9,7,7,9,7,7,9]).Param(7).Result(55)) \
        .Run()

# Test cases
# [1,2,3,4,5,6,1] | 3
# [2,2,2] | 2
# [9,7,7,9,7,7,9] | 7
