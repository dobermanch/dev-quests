
# https://leetcode.com/problems/number-of-provinces

from typing import List
from core.problem_base import *

class NumberOfProvinces(ProblemBase):
    def Solution(self, isConnected: List[List[int]]) -> int:
        size = len(isConnected)

        def dfs(city, visited):
            visited[city] = True

            for i in range(size):
                if isConnected[city][i] and not visited[i]:
                    dfs(i, visited)

        count = 0
        visited = [False] * size
        for i in range(size):
            if visited[i]:
                continue

            count += 1
            dfs(i, visited)

        return count

    def Solution2(self, isConnected: List[List[int]]) -> int:
        size = len(isConnected)

        disjointset = [[i, 1] for i in range(size)]
        def find(x):
            if disjointset[x][0] == x:
                return x

            disjointset[x][0] = find(disjointset[x][0])
            return disjointset[x][0]

        def union(x, y):
            parentX = find(x)
            parentY = find(y)
            if parentX == parentY:
                return

            if disjointset[parentX][1] > disjointset[parentY][1]:
                disjointset[parentY][0] = parentX
            elif disjointset[parentX][1] < disjointset[parentY][1]:
                disjointset[parentX][0] = parentY
            else:
                disjointset[parentY][0] = parentX
                disjointset[parentX][1] += 1

        count = size
        for x in range(size):
            for y in range(size):
                if isConnected[x][y] and find(x) != find(y):
                    count -= 1
                    union(x, y)

        return count

if __name__ == '__main__':
    TestGen(NumberOfProvinces) \
        .Add(lambda tc: tc.Param([[1,1,0],[1,1,0],[0,0,1]]).Result(2)) \
        .Add(lambda tc: tc.Param([[1,0,0],[0,1,0],[0,0,1]]).Result(3)) \
        .Run()

