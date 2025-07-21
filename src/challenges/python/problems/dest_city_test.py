# https://leetcode.com/problems/destination-city

from core.problem_base import *

class DestCity(ProblemBase):
    def Solution(self, paths: list[list[str]]) -> str:
        map = {}
        for path in paths:
            map[path[0]] = map.get(path[0], 0) + 1
            map[path[1]] = map.get(path[1], 0)

        for k, v in map.items():
            if v == 0:
                return k

        return ""

if __name__ == '__main__':
    TestGen(DestCity) \
        .Add(lambda tc: tc.Param([["London","New York"],["New York","Lima"],["Lima","Sao Paulo"]]).Result("Sao Paulo")) \
        .Add(lambda tc: tc.Param([["B","C"],["D","B"],["C","A"]]).Result("A")) \
        .Add(lambda tc: tc.Param([["A","Z"]]).Result("Z")) \
        .Run()
