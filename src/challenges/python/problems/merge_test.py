# https://leetcode.com/problems/add-strings/

from core.problem_base import *

class Merge(ProblemBase):
    def Solution(self, nums1: list[int], m: int, nums2: list[int], n: int) -> list[int]:
        """
        Do not return anything, modify nums1 in-place instead.
        """
        if n == 0:
            return

        i1 = m - 1
        i2 = n - 1
        for i in range(len(nums1) - 1, -1, -1):
            if i2 < 0 or (i1 >= 0 and nums1[i1] > nums2[i2]):
                nums1[i] = nums1[i1]
                i1 -= 1
            else:
                nums1[i] = nums2[i2]
                i2 -= 1
        
        return nums1

if __name__ == '__main__':
    TestGen(Merge) \
        .Add(lambda tc: tc.Param([1,2,3,0,0,0]).Param(3).Param([2,5,6]).Param(3).Result([1,2,2,3,5,6])) \
        .Run()
