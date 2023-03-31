# https://leetcode.com/problems/spiral-matrix-ii/

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class SpiralOrder2:
    def Solution(self, n: int) -> list[list[int]]:
        martix = [[0] * n for _ in range(n)]

        x, y = 0, 0
        dx, dy = 1, 1
        count = 1
        target = n*n

        while count <= target:
            martix[y][x] = count
            count += 1

            if y == dy - 1 and x < n - dx:
                x += 1
            elif x == n - dx and y < n - dy:
                y += 1
            elif x > dx - 1:
                x -= 1
            elif y > dy:
                y -= 1
                if y == dy and x == dx - 1:
                    dx += 1
                    dy += 1

        return martix



SpiralOrder2().Solution(3)
