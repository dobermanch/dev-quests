# https://leetcode.com/problems/pascals-triangle-ii/

class PascalsTriangle2:
    def Solution(self, rowIndex: int) -> list[int]:
        result = [1 for i in range(rowIndex + 1)]

        for i in range(2, rowIndex + 1):
            prev = result[0]
            for j in range(1, rowIndex):
                temp = result[j]
                result[j] = prev + result[j]
                prev = temp

        return result


PascalsTriangle2().Solution(5)
