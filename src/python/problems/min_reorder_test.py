#https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero

from core.problem_base import *

class MinReorder(ProblemBase):
    def Solution(self, n: int, connections: list[list[int]]) -> int:
        def Dfs(current):
            result = 0
            visited.add(current)
            for city, change in neighbors[current]:
                if city in visited:
                    continue

                if change:
                    result += 1
                
                result += Dfs(city)
            return result

        visited = set()
        neighbors = { city:[] for city in range(n) }
        for city1, city2 in connections:
            neighbors[city1].append((city2, True))
            neighbors[city2].append((city1, False))
        
        return Dfs(0)
        

if __name__ == '__main__':
    TestGen(MinReorder) \
        .Add(lambda tc: tc.Param(6).Param([[0,1],[1,3],[2,3],[4,0],[4,5]]).Result(3)) \
        .Add(lambda tc: tc.Param(5).Param([[1,0],[1,2],[3,2],[3,4]]).Result(2)) \
        .Add(lambda tc: tc.Param(3).Param([[1,0],[2,0]]).Result(0)) \
        .Run()
