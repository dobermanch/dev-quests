#https://leetcode.com/problems/n-queens

from collections import defaultdict
from core.problem_base import *

class SolveNQueens(ProblemBase):
    def Solution(self, n: int) -> list[list[str]]:
        result = []
        board = [['.'] * n for _ in range(n)]

        def placeQueens(row):
            if row >= n:
                result.append([])
                for r in range(n):
                    result[-1].append(''.join(board[r]))

            for col in range(n):
                if canPlace(row, col):
                    board[row][col] = 'Q'

                    placeQueens(row + 1)

                    board[row][col] = '.'

        def canPlace(row, col):
            for r in range(0, row):
                if board[r][col] == 'Q':
                    return False
            
            r = row
            c = col
            while r >= 0 and c >= 0:
                if board[r][c] == 'Q':
                    return False
                r -= 1
                c -= 1
            
            r = row
            c = col
            while r >= 0 and c < n:
                if board[r][c] == 'Q':
                    return False
                r -= 1
                c += 1

            return True

        placeQueens(0)

        return result
            

if __name__ == '__main__':
    TestGen(SolveNQueens) \
        .Add(lambda tc: tc.Param("n", 4).Result([[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]])) \
        .Run()
