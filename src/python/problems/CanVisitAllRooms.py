#https://leetcode.com/problems/keys-and-rooms/
class SubarraySum:
    def Solution(self, rooms: List[List[int]]) -> bool:
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


CanVisitAllRooms().Solution(5, [[1,3],[2,0],[2,3],[1,0],[4,1],[0,3]])
