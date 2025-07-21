# https://leetcode.com/problems/combination-sum-iii

from core.problem_base import *

class CombinationSum3(ProblemBase):
    def Solution(self, k: int, n: int) -> list[list[int]]:
        result = []
        edge = min(9, n - k + 1)

        def search(current, temp):
            if len(temp) == k:
                if sum(temp) == n:
                    result.append(list(temp))

                return

            for i in range(current, edge + 1):
                temp.append(i)
                search(i + 1, temp)
                temp.pop()

        search(1, [])

        return result


if __name__ == '__main__':
    TestGen(CombinationSum3) \
        .Add(lambda tc: tc.Param(3).Param(7).Result([[1,2,4]])) \
        .Add(lambda tc: tc.Param(3).Param(9).Result([[1,2,6],[1,3,5],[2,3,4]])) \
        .Add(lambda tc: tc.Param(4).Param(1).Result([])) \
        .Run()
