#https://leetcode.com/problems/find-the-difference-of-two-arrays

from core.problem_base import *

class FindDifference(ProblemBase):
    def Solution(self, nums1: list[int], nums2: list[int]) -> list[list[int]]:
        set1 = set(nums1)
        set2 = set(nums2)

        for i in range(len(nums1)):
            if nums1[i] in set2:
                set1.remove(nums1[i])
                set2.remove(nums1[i])
        
        return [set1, set2]

if __name__ == '__main__':
    TestGen(FindDifference) \
        .Add(lambda tc: tc.Param("nums1", [1,2,3]).Param("nums2", [2,4,6]).Result([[1,3],[4,6]])) \
        .Add(lambda tc: tc.Param("nums1", [1,2,3,3]).Param("nums2", [1,1,2,2]).Result([[3],[]])) \
        .Run()
