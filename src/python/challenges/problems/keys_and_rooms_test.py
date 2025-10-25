#https://leetcode.com/problems/keys-and-rooms/
from core.problem_base import *

class CanVisitAllRooms(ProblemBase):
    def Solution(self, rooms: list[list[int]]) -> bool:
        collectedKeys = set()
        collectedKeys.add(0)

        stack = []
        stack.append(0)

        while stack:
            roomKey = stack.pop()
            for key in rooms[roomKey]:
                if key not in collectedKeys:
                    stack.append(key)
                    collectedKeys.add(key)

        return len(collectedKeys) == len(rooms)

    def Solution1(self, rooms: list[list[int]]) -> bool:
        visited = set()

        def visit(room):
            if room in visited:
                return

            visited.add(room)
            for key in rooms[room]:
                visit(key)

        visit(0)

        return len(visited) == len(rooms)


if __name__ == '__main__':
    TestGen(CanVisitAllRooms) \
        .Add(lambda tc: tc.Param([[1],[2],[3],[]]).Result(True)) \
        .Add(lambda tc: tc.Param([[1,3],[3,0,1],[2],[0]]).Result(False)) \
        .Run()
