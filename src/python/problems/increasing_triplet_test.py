#https://leetcode.com/problems/increasing-triplet-subsequence
import sys
from core.problem_base import *

class IncreasingTriplet(ProblemBase):
    def Solution(self, nums: list[int]) -> bool:
        n1 = sys.maxsize
        n2 = sys.maxsize

        for num in nums:
            if num > n2:
                return True
            
            if num <= n1:
                n1 = num
            elif num < n2:
                n2 = num

        return False

if __name__ == '__main__':
    TestGen(IncreasingTriplet) \
        .Add(lambda tc: tc.Param([1,2,3,4,5]).Result(True)) \
        .Add(lambda tc: tc.Param([5,4,3,2,1]).Result(False)) \
        .Add(lambda tc: tc.Param([2,1,5,0,4,6]).Result(True)) \
        .Run()
