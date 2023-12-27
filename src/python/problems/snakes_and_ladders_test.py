# https://leetcode.com/problems/snakes-and-ladders

from core.problem_base import *

class SnakesAndLadders(ProblemBase):
    def Solution(self, board: list[list[int]]) -> int:
        oneDBoard = [num for index, row in enumerate(reversed(board)) for num in row[::(1 if index % 2 == 0 else -1)]]

        boardLength = len(oneDBoard)
        queue = [(0, 1)]
        visited = [False] * boardLength

        dieSides = 6
        while queue:
            square, moves = queue.pop(0)
            for steps in range(1, dieSides + 1):
                moveTo = square + steps
                if oneDBoard[moveTo] != -1:
                    moveTo = oneDBoard[moveTo] - 1

                if moveTo == boardLength - 1:
                    return moves

                if not visited[moveTo]:
                    queue.append((moveTo, moves + 1))

                visited[moveTo] = True

        return -1

if __name__ == '__main__':
    TestGen(SnakesAndLadders) \
        .Add(lambda tc: tc.Param([[1,1,-1],[1,1,1],[-1,1,1]]).Result(-1)) \
        .Add(lambda tc: tc.Param([[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1]]).Result(4)) \
        .Add(lambda tc: tc.Param([[-1,-1],[-1,3]]).Result(1)) \
        .Add(lambda tc: tc.Param([[-1,1,2,-1],[2,13,15,-1],[-1,10,-1,-1],[-1,6,2,8]]).Result(2)) \
        .Add(lambda tc: tc.Param([[-1,-1,30,14,15,-1],[23,9,-1,-1,-1,9],[12,5,7,24,-1,30],[10,-1,-1,-1,25,17],[32,-1,28,-1,-1,32],[-1,-1,23,-1,13,19]]).Result(2)) \
        .Add(lambda tc: tc.Param([[-1,-1,27,13,-1,25,-1],[-1,-1,-1,-1,-1,-1,-1],[44,-1,8,-1,-1,2,-1],[-1,30,-1,-1,-1,-1,-1],[3,-1,20,-1,46,6,-1],[-1,-1,-1,-1,-1,-1,29],[-1,29,21,33,-1,-1,-1]]).Result(4)) \
        .Add(lambda tc: tc.Param([[-1,-1,19,10,-1],[2,-1,-1,6,-1],[-1,17,-1,19,-1],[25,-1,20,-1,-1],[-1,-1,-1,-1,15]]).Result(2)) \
        .Run()
