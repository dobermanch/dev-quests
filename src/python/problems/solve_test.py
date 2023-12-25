# https://leetcode.com/problems/surrounded-regions

from core.problem_base import *

class Solve(ProblemBase):
    def Solution(self, board: list[list[str]]) -> list[list[str]]:
        """
        Do not return anything, modify board in-place instead.
        """
        rows = len(board)
        cols = len(board[0])

        def mark(board, y, x):
            if y < 0 or y >= rows \
                or x < 0 or x >= cols \
                or board[y][x] != 'O':
                return

            board[y][x] = 'o'

            mark(board, y + 1, x)
            mark(board, y - 1, x)
            mark(board, y, x + 1)
            mark(board, y, x - 1)

        for col in range(cols):
            mark(board, 0, col)
            mark(board, rows - 1, col)

        for row in range(rows):
            mark(board, row, 0)
            mark(board, row, cols - 1)

        for row in range(rows):
            for col in range(cols):
                board[row][col] = 'O' if board[row][col] == 'o' else 'X'

        return board

if __name__ == '__main__':
    TestGen(Solve) \
        .Add(lambda tc: tc.Param([["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]).Result([["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]])) \
        .Add(lambda tc: tc.Param([["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","O","X"]]).Result([["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","O","X"]])) \
        .Add(lambda tc: tc.Param([["X"]]).Result([["X"]])) \
        .Run()
