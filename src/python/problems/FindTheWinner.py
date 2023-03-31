#https://leetcode.com/problems/find-the-winner-of-the-circular-game/
class FindTheWinner:
    def Solution(self, n: int, k: int) -> int:
        players = list(range(n))
        index = k - 1

        while len(players) > 1:
            del players[index]
            index = (index + k - 1) % len(players)

        return players[0]


FindTheWinner().Solution(5, 2)
