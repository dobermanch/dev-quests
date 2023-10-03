# https://leetcode.com/problems/unique-number-of-occurrences

from core.problem_base import *

class UniqueOccurrences(ProblemBase):
    def Solution(self, arr: list[int]) -> bool:
        map = {}
        for i in range(len(arr)):
            if arr[i] not in map:
                map[arr[i]] = 1
            else:
                map[arr[i]] += 1
        
        unique = set(map.values())

        return len(unique) == len(map.values())
        
if __name__ == '__main__':
    TestGen(UniqueOccurrences) \
        .Add(lambda tc: tc.Param("arr", [1,2,2,1,1,3]).Result(True)) \
        .Add(lambda tc: tc.Param("arr", [1,2]).Result(False)) \
        .Add(lambda tc: tc.Param("arr", [-3,0,1,-3,1,1,1,-3,10,0]).Result(True)) \
        .Run()
