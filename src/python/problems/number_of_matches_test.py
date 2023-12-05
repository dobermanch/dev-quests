# https://leetcode.com/problems/count-of-matches-in-tournament

from core.problem_base import *

class NumberOfMatches(ProblemBase):
    def Solution(self, n: int) -> int:
        matches = 0
        teams = n

        while teams > 1:
            matches += teams // 2
            teams = teams // 2 + teams % 2

        return matches

if __name__ == '__main__':
    TestGen(NumberOfMatches) \
        .Add(lambda tc: tc.Param(7).Result(6)) \
        .Add(lambda tc: tc.Param(14).Result(13)) \
        .Run()
