
# https://leetcode.com/problems/sudoku-solver

from typing import List
from core.problem_base import *

class SudokuSolver(ProblemBase):
    def Solution(self, board: List[List[str]]) -> List[List[str]]:
        size = len(board)
        cols = [[False for _ in range(size)] for _ in range(size)]
        rows = [[False for _ in range(size)] for _ in range(size)]
        blocks = [[False for _ in range(size)] for _ in range(size)]

        for row in range(size):
            for col in range(size):
                if board[row][col] == ".":
                    continue

                val = int(board[row][col]) - 1

                cols[col][val] = True
                rows[row][val] = True

                blockIndex = row // 3 * 3 + col // 3
                blocks[blockIndex][val] = True

        def solve(row: int, col: int) -> bool:
            if row >= size:
                return True

            if col >= size:
                return solve(row + 1, 0)

            if board[row][col] != ".":
                return solve(row, col + 1)

            for num in range(9):
                blockIndex = row // 3 * 3 + col // 3
                if cols[col][num] or rows[row][num] or blocks[blockIndex][num]:
                    continue

                cols[col][num] = True
                rows[row][num] = True
                blocks[blockIndex][num] = True

                solved = False
                if col + 1 >= size:
                    solved = solve(row + 1, 0)
                else:
                    solved = solve(row, col + 1)

                if solved:
                    board[row][col] = str(num + 1)
                    return True

                cols[col][num] = False
                rows[row][num] = False
                blocks[blockIndex][num] = False

            return False

        solve(0, 0)

        return board

if __name__ == '__main__':
    TestGen(SudokuSolver) \
        .Add(lambda tc: tc.Param([["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]).Result([["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]) ) \
        .Run()
