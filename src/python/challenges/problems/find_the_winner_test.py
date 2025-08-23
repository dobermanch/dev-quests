#https://leetcode.com/problems/find-the-winner-of-the-circular-game/
from core.problem_base import *

class FindTheWinner(ProblemBase):
    def Solution(self, n: int, k: int) -> int:
        players = list(range(1, n + 1))
        index = k - 1

        while len(players) > 1:
            del players[index]
            index = (index + k - 1) % len(players)

        return players[0]


if __name__ == '__main__':
    TestGen(FindTheWinner) \
        .Add(lambda tc: tc.Param(5).Param(2).Result(3)) \
        .Add(lambda tc: tc.Param(6).Param(5).Result(1)) \
        .Run()