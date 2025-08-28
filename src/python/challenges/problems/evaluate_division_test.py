#https://leetcode.com/problems/evaluate-division/

from collections import defaultdict
from core.problem_base import *

class CalcEquation(ProblemBase):
    def Solution(self, equations: list[list[str]], values: list[float], queries: list[list[str]]) -> list[float]:
        def Dfs(current, target, visited):
            if current not in nodes or target not in nodes:
                return -1
            
            if current == target:
                return 1
            
            visited.add(current)
            for node, weight in nodes[current]:
                if node in visited:
                    continue
                
                result = Dfs(node, target, visited)
                if result > 0:
                    return result * weight

            return -1

        nodes = defaultdict(list)
        for i in range(len(equations)):
            nodes[equations[i][0]].append((equations[i][1], values[i]))
            nodes[equations[i][1]].append((equations[i][0], 1 / values[i]))

        result = []
        for startNode, endNode in queries:
            result.append(Dfs(startNode, endNode, set()))
        
        return result
            

if __name__ == '__main__':
    TestGen(CalcEquation) \
        .Add(lambda tc: tc.Param([["a","b"],["b","c"]]) \
                          .Param([2.0,3.0]) \
                          .Param([["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]) \
                          .Result([6.00000,0.50000,-1.00000,1.00000,-1.00000])) \
        .Run()
