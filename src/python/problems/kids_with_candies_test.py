# https://leetcode.com/problems/kids-with-the-greatest-number-of-candies

from core.problem_base import *

class KidsWithCandies(ProblemBase):
    def Solution(self, candies: list[int], extraCandies: int) -> list[bool]:
        maxCandies = max(candies)

        result = []
        for i in range(len(candies)):
            result.append(candies[i] + extraCandies >= maxCandies)
        
        return result

if __name__ == '__main__':
    TestGen(KidsWithCandies) \
        .Add(lambda tc: tc.Param([2,3,5,1,3]).Param(3).Result([True,True,True,False,True])) \
        .Add(lambda tc: tc.Param([4,2,1,1,2]).Param(1).Result([True,False,False,False,False])) \
        .Add(lambda tc: tc.Param([12,1,12]).Param(10).Result([True,False,True])) \
        .Run()
