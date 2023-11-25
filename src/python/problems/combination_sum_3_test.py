# https://leetcode.com/problems/combination-sum-iii

from core.problem_base import *
import collections

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
        .Add(lambda tc: tc.Param("k", 3).Param("n", 7).Result([[1,2,4]])) \
        .Add(lambda tc: tc.Param("k", 3).Param("n", 9).Result([[1,2,6],[1,3,5],[2,3,4]])) \
        .Add(lambda tc: tc.Param("k", 4).Param("n", 1).Result([])) \
        .Run()
