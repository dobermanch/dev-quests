
# https://leetcode.com/problems/alice-and-bob-playing-flower-game

from typing import List
from core.problem_base import *

class AliceAndBobPlayingFlowerGame(ProblemBase):
    def Solution(self, n: int, m: int) -> int:
        n_even = n // 2
        n_odd = n_even if n % 2 == 0 else n_even + 1

        m_even = m // 2
        m_odd = m_even if m % 2 == 0 else m_even + 1

        return n_even * m_odd + n_odd * m_even

if __name__ == '__main__':
    TestGen(AliceAndBobPlayingFlowerGame) \
        .Add(lambda tc: tc.Param(10).Param(3).Result(15) ) \
        .Add(lambda tc: tc.Param(1).Param(1).Result(0) ) \
        .Add(lambda tc: tc.Param(3).Param(2).Result(3) ) \
        .Run()
