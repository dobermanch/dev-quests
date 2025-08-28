# https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array

from core.problem_base import *

class FindSpecialInteger(ProblemBase):
    def Solution1(self, arr: list[int]) -> int:
        minCount = len(arr) // 4
        for i in range(len(arr) - minCount):
            if arr[i] == arr[i + minCount]:
                return arr[i]

        return arr[0]
    
    def Solution2(self, arr: list[int]) -> int:
        minCount = len(arr) // 4
        count = 1
        for i in range(1, len(arr)):
            count = count + 1 if arr[i - 1] == arr[i] else 1
            if count > minCount:
                return arr[i]

        return arr[0]

if __name__ == '__main__':
    TestGen(FindSpecialInteger) \
        .Add(lambda tc: tc.Param([1,2,2,6,6,6,6,7,10]).Result(6)) \
        .Add(lambda tc: tc.Param([1,1]).Result(1)) \
        .Add(lambda tc: tc.Param([1,1,2,2,3,3,3,3]).Result(3)) \
        .Run()
