#https://leetcode.com/problems/equal-row-and-column-pairs/

from collections import Counter, defaultdict
from core.problem_base import *

class EqualPairs(ProblemBase):
    def Solution(self, grid: list[list[int]]) -> int:        
        rows = Counter(tuple(row) for row in grid)
        
        return sum(rows[c] for c in zip(*grid))
    
    def Solution1(self, grid: list[list[int]]) -> int:
        colMap = defaultdict(list[int])
        for c in range(len(grid)):
            colMap[grid[0][c]].append(c)

        result = 0
        for r in range(len(grid)):
            if grid[r][0] not in colMap:
                continue
        
            for col in colMap[grid[r][0]]:
                matched = True
                for i in range(len(grid)):
                    if grid[i][col] != grid[r][i]:
                        matched = False
                        break

                if matched:
                    result += 1

        return result

if __name__ == '__main__':
    TestGen(EqualPairs) \
        .Add(lambda tc: tc.Param([[3,2,1],[1,7,6],[2,7,7]]).Result(1)) \
        .Add(lambda tc: tc.Param([[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]).Result(3)) \
        .Run()
