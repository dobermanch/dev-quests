
# https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix

from typing import List
from core.problem_base import *

class KthSmallestElementInASortedMatrix(ProblemBase):
    def Solution(self, matrix: List[List[int]], k: int) -> int:
        n = len(matrix)

        result = matrix[-1][-1]
        left = matrix[0][0]
        right = matrix[-1][-1]
        while left < right:
            mid = (left + right) // 2

            target = 0
            for i in range(n):
                if matrix[i][0] > mid:
                    break

                l = 0
                r = n - 1
                while l <= r:
                    m = (l + r) // 2
                    if matrix[i][m] <= mid:
                        l = m + 1
                    else:
                        r = m - 1
                target += l

            if target < k:
                left = mid + 1
            else:
                result = mid
                right = mid

        return result

if __name__ == '__main__':
    TestGen(KthSmallestElementInASortedMatrix) \
        .Add(lambda tc: tc.Param([[-5,-4],[-5,-4]]).Param(2).Result(-4) ) \
        .Add(lambda tc: tc.Param([[1,5,7,9],[2,6,8,10],[3,7,8,11],[7,8,9,12]]).Param(4).Result(5) ) \
        .Add(lambda tc: tc.Param([[1,2],[1,3]]).Param(4).Result(3) ) \
        .Add(lambda tc: tc.Param([[1,5,9],[10,11,13],[12,13,15]]).Param(8).Result(13) ) \
        .Add(lambda tc: tc.Param([[-5]]).Param(1).Result(-5) ) \
        .Run()
