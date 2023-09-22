#https://leetcode.com/problems/median-of-two-sorted-arrays/

from core.problem_base import *

class FindMedianSortedArrays(ProblemBase):
    def Solution(self, nums1: list[int], nums2: list[int]) -> float:
        if len(nums1) > len(nums2):
            nums1, nums2 = nums2, nums1

        m = len(nums1)
        n = len(nums2)
        length = m + n
        partition = (length + 1) // 2
        left = 0
        right = m

        while left <= right:
            mid1 = (left + right) // 2
            mid2 = partition - mid1

            m1 = nums1[mid1 - 1] if mid1 > 0 else float("-inf")    
            l1 = nums1[mid1] if mid1 < m else float("inf")

            m2 = nums2[mid2 - 1] if mid2 > 0 else float("-inf")
            l2 = nums2[mid2] if mid2 < n else float("inf")

            if m1 <= l2 and m2 <= l1:
                if length % 2 == 0:
                    return (max(m1, m2) + min(l1, l2)) / 2
                return max(m1, m2)
        
            if m1 > l2:
                right = mid1 - 1
            else:
                left = mid1 + 1
      
        return 0

if __name__ == '__main__':
    TestGen(FindMedianSortedArrays) \
        .Add(lambda tc: tc.Param("nums1", [1,2,3,4,5]).Param("nums2", [1,2,3,4,5,6,7,8]).Result(4.0)) \
        .Add(lambda tc: tc.Param("nums1", [1,2,3,4]).Param("nums2", [1,2,3,4,5,6,7,8]).Result(3.5)) \
        .Add(lambda tc: tc.Param("nums1", [1,3]).Param("nums2", [2]).Result(2.0)) \
        .Add(lambda tc: tc.Param("nums1", [1,2]).Param("nums2", [3,4]).Result(2.5)) \
        .Run()
