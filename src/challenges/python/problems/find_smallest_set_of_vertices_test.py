#https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/

from core.problem_base import *

class FindSmallestSetOfVertices(ProblemBase):
    def Solution(self, n: int, edges: list[list[int]]) -> list[int]:
        result = set(range(n))

        for edge in edges:
            if edge[1] in result:
                result.remove(edge[1])
        
        return list(result)


if __name__ == '__main__':
    TestGen(FindSmallestSetOfVertices) \
        .Add(lambda tc: tc.Param(6).Param([[0,1],[0,2],[2,5],[3,4],[4,2]]).Result([0,3])) \
        .Add(lambda tc: tc.Param(5).Param([[0,1],[2,1],[3,1],[1,4],[2,4]]).Result([0,2,3])) \
        .Run()

