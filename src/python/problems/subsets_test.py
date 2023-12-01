#https://leetcode.com/problems/subsets/

from core.problem_base import *

class Subsets(ProblemBase):
    def Solution(self, nums: list[int]) -> list[list[int]]:
        result = []

        def search(index, temp):
            result.append(temp.copy())

            for i in range(index, len(nums)):
                temp.append(nums[i])
                search(i + 1, temp)
                temp.pop()

        search(0, [])

        return result

if __name__ == '__main__':
    TestGen(Subsets) \
        .Add(lambda tc: tc.Param([1,2,3]).Result([[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]])) \
        .Add(lambda tc: tc.Param([0]).Result([[],[0]])) \
        .Run()
