# https://leetcode.com/problems/game-of-life

from core.problem_base import *

class GameOfLife(ProblemBase):
    def Solution(self, board: list[list[int]]) -> list[list[int]]:
        """
        Do not return anything, modify board in-place instead.
        """
        directions = [
            [ -1, -1 ], [ -1, 0 ], [ -1, 1 ],
            [  0, -1 ],            [  0, 1 ],
            [  1, -1 ], [  1, 0 ], [  1, 1 ],
        ]

        count = len(directions)
        rows = len(board)
        cols = len(board[0])

        for row in range(rows):
            for col in range(cols):
                neighbors = 0

                for i in range(count):
                    y = row + directions[i][0]
                    x = col + directions[i][1]

                    if y >= 0 and y < rows \
                        and x >= 0 and x < cols \
                        and (board[y][x] == 1 or board[y][x] >= 20):
                        neighbors += 1

                board[row][col] = neighbors + (10 if board[row][col] == 0 else 20)

        for row in range(rows):
            for col in range(cols):
                neighbors = board[row][col] - (20 if board[row][col] >= 20 else 10)

                if neighbors < 2 or neighbors > 3:
                    board[row][col] = 0
                elif neighbors == 3 and board[row][col] < 20:
                    board[row][col] = 1
                elif board[row][col] >= 20:
                    board[row][col] = 1
                else:
                    board[row][col] = 0
        
        return board

if __name__ == '__main__':
    TestGen(GameOfLife) \
        .Add(lambda tc: tc.Param([[0,1,0],[0,0,1],[1,1,1],[0,0,0]]).Result([[0,0,0],[1,0,1],[0,1,1],[0,1,0]])) \
        .Add(lambda tc: tc.Param([[1,1],[1,0]]).Result([[1,1],[1,1]])) \
        .Run()
