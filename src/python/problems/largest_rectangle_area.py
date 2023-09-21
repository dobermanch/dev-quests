#https://leetcode.com/problems/largest-rectangle-in-histogram/

from heapq import heappop, heappush
from core.problem_base import *

class LargestRectangleArea(ProblemBase):
    def Solution(self, heights: list[int]) -> int:
        stack = []
        result = 0
        count = 0

        for i in range(len(heights)):
            count = 0
            while stack and heights[i] <= stack[-1][0]:
                height, count1 = stack.pop()
                count += count1
                result = max(result, height * count)
            
            stack.append((heights[i], count + 1))
        
        count = 0
        while stack:
            height, count1 = stack.pop()
            count += count1
            result = max(result, height * count)

        return result

if __name__ == '__main__':
    TestGen(LargestRectangleArea) \
        .Add(lambda tc: tc.Param("heights", [4,2]).Result(4)) \
        .Add(lambda tc: tc.Param("heights", [1]).Result(1)) \
        .Add(lambda tc: tc.Param("heights", [1,1]).Result(2)) \
        .Add(lambda tc: tc.Param("heights", [3,6,5,7,4,8,1,0]).Result(20)) \
        .Add(lambda tc: tc.Param("heights", [4,2,0,3,2,4,3,4]).Result(10)) \
        .Add(lambda tc: tc.Param("heights", [5,4,1,2]).Result(8)) \
        .Add(lambda tc: tc.Param("heights", [1,2,3,4,5]).Result(9)) \
        .Add(lambda tc: tc.Param("heights", [2,1,5,6,2,3,2,3]).Result(12)) \
        .Add(lambda tc: tc.Param("heights", [2,1,5,6,2,3]).Result(10)) \
        .Add(lambda tc: tc.Param("heights", [2,4]).Result(4)) \
        .Run()
