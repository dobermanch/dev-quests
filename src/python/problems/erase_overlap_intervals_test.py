# https://leetcode.com/problems/non-overlapping-intervals/


class EraseOverlapIntervals:
    def Solution(self, intervals: list[list[int]]) -> int:
        result = 0
        intervals.sort(key = lambda x: x[0])
        current = intervals[0]
        for i in range(1, len(intervals)):
            if current[1] > intervals[i][0]:
                result += 1
                current = current if current[1] <= intervals[i][1] else intervals[i]
            else:
                current = intervals[i]

        return result



EraseOverlapIntervals().Solution([[1,2],[2,3],[3,4],[1,3]])
