#https://leetcode.com/problems/subsets-ii/

from core.problem_base import *

class SubsetsWithDup(ProblemBase):
    def Solution(self, nums: list[int]) -> list[list[int]]:
        result = []

        def search(index, temp):
            result.append(temp.copy())        

            for i in range(index, len(nums)):
                if i > index and nums[i] == nums[i - 1]:
                    continue

                temp.append(nums[i])
                search(i + 1, temp)
                temp.pop()

        nums.sort()
        search(0, [])

        return result

if __name__ == '__main__':
    TestGen(SubsetsWithDup) \
        .Add(lambda tc: tc.Param("nums", [1,2,3]).Result([[],[1],[1,2],[1,2,2],[2],[2,2]])) \
        .Add(lambda tc: tc.Param("nums", [4,4,4,1,4]).Result([[],[1],[1,4],[1,4,4],[1,4,4,4],[1,4,4,4,4],[4],[4,4],[4,4,4],[4,4,4,4]])) \
        .Add(lambda tc: tc.Param("nums", []).Result([[],[0]])) \
        .Run()
