#https://leetcode.com/problems/n-th-tribonacci-number/

from core.problem_base import *

class Tribonacci(ProblemBase):
    def Solution(self, n: int) -> int:
        if n == 0:
            return 0

        if n <= 2:
            return 1

        n1 = 1
        n2 = 1
        n3 = 2
        while n > 3:    
            n -= 1
            next = n1 + n2 + n3
            n1 = n2
            n2 = n3
            n3 = next

        return n3

if __name__ == '__main__':
    TestGen(Tribonacci) \
        .Add(lambda tc: tc.Param(4).Result(4)) \
        .Add(lambda tc: tc.Param(25).Result(1389537)) \
        .Run()
