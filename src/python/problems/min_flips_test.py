#https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/

from core.problem_base import *

class MinFlips(ProblemBase):
    def Solution(self, a: int, b: int, c: int) -> int:
        result = 0
        for i in range(32):
            ar = (1 << i) & a
            br = (1 << i) & b
            cr = (1 << i) & c

            if (ar | br) == cr:
                continue

            if ar == 0 and br == 0:
                result += 1
                continue

            if ar > 0:
                result += 1

            if br > 0:
                result += 1

        return result

if __name__ == '__main__':
    TestGen(MinFlips) \
        .Add(lambda tc: tc.Param("a", 2).Param("b", 6).Param("c", 5).Result(3)) \
        .Add(lambda tc: tc.Param("a", 4).Param("b", 2).Param("c", 7).Result(1)) \
        .Add(lambda tc: tc.Param("a", 1).Param("b", 2).Param("c", 3).Result(0)) \
        .Run()
