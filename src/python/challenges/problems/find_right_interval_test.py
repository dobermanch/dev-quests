# https://leetcode.com/problems/find-right-interval

from typing import List
from core.problem_base import *

class FindRightInterval(ProblemBase):
    def Solution(self, intervals: List[List[int]]) -> List[int]:
        length = len(intervals)

        sorted_intervals = [[intervals[i][0], i] for i in range(length)]
        sorted_intervals.sort(key=lambda x: x[0])

        result = []

        for index in range(length):
            left = 0
            right = length - 1

            target = intervals[index][1]
            while left <= right:
                mid = (left + right) // 2

                if sorted_intervals[mid][0] < target:
                    left = mid + 1
                else:
                    right = mid - 1

            result.append(sorted_intervals[left][2] if left >=0 and left < length else -1)

        return result

if __name__ == '__main__':
    TestGen(FindRightInterval) \
        .Add(lambda tc: tc.Param([[1,12],[2,9],[3,10],[13,14],[15,16],[16,17]]).Result([3,3,3,4,5,-1])) \
        .Add(lambda tc: tc.Param([[1,2],[2,3],[0,1],[3,4]]).Result([1,3,0,-1])) \
        .Add(lambda tc: tc.Param([[1,2]]).Result([-1])) \
        .Add(lambda tc: tc.Param([[4,4]]).Result([0])) \
        .Add(lambda tc: tc.Param([[3,4],[2,3],[1,2]]).Result([-1,0,1])) \
        .Add(lambda tc: tc.Param([[1,4],[2,3],[3,4]]).Result([-1,2,-1])) \
        .Run()