#https://leetcode.com/problems/powx-n/

from core.problem_base import *

class MyPow(ProblemBase):
    def Solution(self, x: float, n: int) -> float:
        if x == 0:
            return 0

        pow = n
        num = x
        if pow < 0:
            pow = -pow
            num = 1 / num
        
        result = 1
        while pow != 0:
            if pow % 2 != 0:
                result *= num
            
            num *= num
            pow //= 2

        return result

if __name__ == '__main__':
    TestGen(MyPow) \
        .Add(lambda tc: tc.Param("x", 2.0).Param("n", 10).Result(1024.0)) \
        .Add(lambda tc: tc.Param("x", 2.1).Param("n", 3).Result(9.26100)) \
        .Add(lambda tc: tc.Param("x", 2.0).Param("n", 0).Result(1.0)) \
        .Add(lambda tc: tc.Param("x", 0.0).Param("n", 21).Result(0.0)) \
        .Add(lambda tc: tc.Param("x", 2.0).Param("n", -2147483648).Result(0.0)) \
        .Add(lambda tc: tc.Param("x", 1.0).Param("n", -2147483648).Result(1.0)) \
        .Add(lambda tc: tc.Param("x", -1.0).Param("n", -2147483648).Result(1.0)) \
        .Add(lambda tc: tc.Param("x", -1.0).Param("n", 2147483647).Result(-1.0)) \
        .Add(lambda tc: tc.Param("x", 1.0).Param("n", 2147483647).Result(1.0)) \
        .Add(lambda tc: tc.Param("x", 1.0000000000001).Param("n", -2147483648).Result(0.99979)) \
        .Add(lambda tc: tc.Param("x", -5.0).Param("n", -12).Result(0.0)) \
        .Add(lambda tc: tc.Param("x", 2.0).Param("n", -2).Result(0.25)) \
        .Run()
