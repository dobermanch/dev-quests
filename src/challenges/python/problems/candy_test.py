# https://leetcode.com/problems/candy

from core.problem_base import *

class Candy(ProblemBase):
    def Solution(self, ratings: list[int]) -> int:
        result = 1
        increase = 0
        decrease = 0
        maxCandy = 0
        for i in range(1, len(ratings)):
            if ratings[i - 1] < ratings[i]:
                increase += 1
                maxCandy = increase
                result += increase + 1
                decrease = 0
            elif ratings[i - 1] > ratings[i]:
                decrease += 1
                increase = 0
                result += decrease + (0 if maxCandy >= decrease else 1)
            else:
                result += 1
                decrease = 0
                maxCandy = 0
                increase = 0

        return result

if __name__ == '__main__':
    TestGen(Candy) \
        .Add(lambda tc: tc.Param([1,0,2]).Result(5)) \
        .Add(lambda tc: tc.Param([1,2,2]).Result(4)) \
        .Add(lambda tc: tc.Param([6,7,6,5,4,3,2,1,0,0,0,1,0]).Result(42)) \
        .Run()
