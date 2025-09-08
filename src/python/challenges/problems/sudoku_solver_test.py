
# https://leetcode.com/problems/sudoku-solver

from typing import List
from core.problem_base import *

class SudokuSolver(ProblemBase):
    def Solution(self, board: List[List[str]]) -> None:
        # Solution is here

if __name__ == '__main__':
    TestGen(SudokuSolver) \
        .Add(lambda tc: Test cases here ) \
        .Run()

# Test cases
# [["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
