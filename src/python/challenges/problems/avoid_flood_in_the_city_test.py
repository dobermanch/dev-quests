
# https://leetcode.com/problems/avoid-flood-in-the-city

from typing import List
from core.problem_base import *
from sortedcontainers import SortedList

class AvoidFloodInTheCity(ProblemBase):
    def Solution(self, rains: List[int]) -> List[int]:
        result = []
        rivers = {}
        dry_days = SortedList()

        for i, rain in enumerate(rains):
            if rain <= 0:
                dry_days.add(i)
                result.append(1)
                continue

            result.append(-1)

            if rain in rivers:
                day = dry_days.bisect(rivers[rain])
                if day == len(dry_days):
                    return []

                result[dry_days[day]] = rain
                dry_days.discard(dry_days[day])

            rivers[rain] = i

        return result

if __name__ == '__main__':
    TestGen(AvoidFloodInTheCity) \
        .Add(lambda tc: tc.Param([1,2,3,4]).Result([-1,-1,-1,-1]) ) \
        .Add(lambda tc: tc.Param([1,2,0,0,2,1]).Result([-1,-1,2,1,-1,-1]) ) \
        .Add(lambda tc: tc.Param([1,2,0,1,2]).Result([]) ) \
        .Add(lambda tc: tc.Param([1,1,0,0]).Result([]) ) \
        .Run()

