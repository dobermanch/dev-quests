# https://leetcode.com/problems/nearest-exit-from-entrance-in-maze

from core.problem_base import *

class NearestExit(ProblemBase):
    def Solution(self, maze: list[list[str]], entrance: list[int]) -> int:
        direction = [[1, 0], [-1, 0], [0, 1], [0, -1]]
        queue = []
        rows = len(maze)
        cols = len(maze[0])

        queue.append((0, entrance[1], entrance[0]))
        while queue:
            (count, x, y) = queue.pop(0)

            if (x == 0 or x == cols - 1 or y == 0 or y == rows - 1) \
                and (x != entrance[1] or y != entrance[0]):
                return count

            for i in range(len(direction)):
                x1 = x + direction[i][0]
                y1 = y + direction[i][1]
                if x1 >= 0 and x1 < cols \
                   and y1 >= 0 and y1 < rows \
                   and maze[y1][x1] != '+':
                    queue.append((count + 1, x1, y1))
                    maze[y1][x1] = '+'

        return -1

if __name__ == '__main__':
    TestGen(NearestExit) \
        .Add(lambda tc: tc.Param([["+","+",".","+"],[".",".",".","+"],["+","+","+","."]]).Param([1,2]).Result(1)) \
        .Add(lambda tc: tc.Param([["+","+","+"],[".",".","."],["+","+","+"]]).Param([1,0]).Result(2)) \
        .Add(lambda tc: tc.Param([[".","+"]]).Param([0,0]).Result(-1)) \
        .Run()
