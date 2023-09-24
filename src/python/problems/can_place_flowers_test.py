#https://leetcode.com/problems/can-place-flowers/

from core.problem_base import *

class CanPlaceFlowers(ProblemBase):
    def Solution(self, flowerbed: list[int], n: int) -> bool:
        flowerbed = [0] + flowerbed + [0]
        left = n
        plot = 1

        while left > 0 and plot < len(flowerbed) - 1:
            if flowerbed[plot] == 1:
                plot += 1
            elif flowerbed[plot - 1] == 0 and flowerbed[plot + 1] == 0:
                flowerbed[plot] = 1
                plot += 1
                left -= 1 
            
            plot += 1

        return left == 0

if __name__ == '__main__':
    TestGen(CanPlaceFlowers) \
        .Add(lambda tc: tc.Param("flowerbed", [1,0,0,0,1]).Param(1).Result(True)) \
        .Add(lambda tc: tc.Param("flowerbed", [1,0,0,0,1]).Param(2).Result(False)) \
        .Add(lambda tc: tc.Param("flowerbed", [1,0,0,0,0]).Param(2).Result(True)) \
        .Run()
