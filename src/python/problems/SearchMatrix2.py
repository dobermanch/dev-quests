# https://leetcode.com/problems/search-a-2d-matrix-ii/

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class SearchMatrix2:
    def Solution(self, matrix: list[list[int]], target: int) -> bool:
        row = 0
        col = len(matrix[0]) - 1

        while row < len(matrix) and col >= 0:
            if matrix[row][col] == target:
                return True

            if matrix[row][col] > target:
                col -= 1
            else:
                row += 1

        return False



SearchMatrix2().Solution([[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]])
