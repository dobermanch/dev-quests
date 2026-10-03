
# https://leetcode.com/problems/fruit-into-baskets

from typing import List
from core.problem_base import *

class FruitIntoBaskets(ProblemBase):
    def Solution(self, fruits: list[int]) -> int:
        map = {}

        left = 0
        result = 0
        for right in range(len(fruits)):
            map[fruits[right]] = map.get(fruits[right], 0) + 1

            if len(map) > 2:
                result = max(result, right - left)
                while len(map) > 2:
                    map[fruits[left]] -= 1
                    if map[fruits[left]] == 0:
                        del map[fruits[left]]
                    left += 1


        return max(result, right - left + 1)

if __name__ == '__main__':
    TestGen(FruitIntoBaskets) \
        .Add(lambda tc: tc.Param([0,1,1,4,3]).Result(3)) \
        .Add(lambda tc: tc.Param([1,2,1,2,2,3,3,2,2,2]).Result(7)) \
        .Add(lambda tc: tc.Param([1,2,1]).Result(3)) \
        .Add(lambda tc: tc.Param([0,1,2,2]).Result(3)) \
        .Add(lambda tc: tc.Param([1,2,3,2,2]).Result(4)) \
        .Run()

# Test cases
# [1,2,1]
# [0,1,2,2]
# [1,2,3,2,2]
