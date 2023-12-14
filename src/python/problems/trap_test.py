# https://leetcode.com/problems/trapping-rain-water

from core.problem_base import *

class Trap(ProblemBase):
    def Solution(self, height: list[int]) -> int:
        left = 0
        right = len(height) - 1
        maxL, maxR = 0, 0
        trap = 0

        while left <= right:
            if maxL < maxR:
                if maxL - height[left] > 0:
                    trap += maxL - height[left]

                maxL = max(maxL, height[left])
                left += 1
            else:
                if maxR - height[right] > 0:
                    trap += maxR - height[right]
                    
                maxR = max(maxR, height[right])
                right -= 1

        return trap

if __name__ == '__main__':
    TestGen(Trap) \
        .Add(lambda tc: tc.Param([0,1,0,2,1,0,1,3,2,1,2,1]).Result(6)) \
        .Add(lambda tc: tc.Param([4,2,0,3,2,5]).Result(9)) \
        .Run()
