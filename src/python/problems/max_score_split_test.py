# https://leetcode.com/problems/maximum-score-after-splitting-a-string

from core.problem_base import *

class MaxScoreSplit(ProblemBase):
    def Solution(self, s: str) -> int:
        oneCount = 0
        for i in range(len(s)):
            if s[i] == '1':
                oneCount += 1

        zeroCount = 0
        score = 0
        for i in range(len(s) - 1):
            if s[i] == '0':
                zeroCount += 1
            else:
                oneCount -= 1

            score = max(score, zeroCount + oneCount)

        return score

if __name__ == '__main__':
    TestGen(MaxScoreSplit) \
        .Add(lambda tc: tc.Param("011101").Result(5)) \
        .Add(lambda tc: tc.Param("00111").Result(5)) \
        .Add(lambda tc: tc.Param("1111").Result(3)) \
        .Run()
