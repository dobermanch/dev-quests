#https://leetcode.com/problems/majority-element/
from core.problem_base import *

class MajorityElement(ProblemBase):
    def Solution(self, nums: list[int]) -> int:
        result = 0
        count = 0

        for num in nums:
            if count == 0:
                result = num

            count += 1 if result == num else -1
        
        return result


if __name__ == '__main__':
    TestGen(MajorityElement) \
        .Add(lambda tc: tc.Param([3,2,3]).Result(3)) \
        .Add(lambda tc: tc.Param([2,2,1,1,1,2,2]).Result(2)) \
        .Run()
