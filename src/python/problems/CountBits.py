#https://leetcode.com/problems/counting-bits/
class CountBits:
    def Solution(self, n: int) -> list[int]:
        result = [0] * (n + 1)

        for i in range(1, n + 1):
            result[i] = result[i & i - 1] + 1

        return result


CountBits().Solution(10)
