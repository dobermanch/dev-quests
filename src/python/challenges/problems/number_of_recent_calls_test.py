
# https://leetcode.com/problems/number-of-recent-calls

from collections import deque
from typing import List
from core.problem_base import *

class NumberOfRecentCalls(ProblemBase):
    def Solution(self, commands: List[str], values: List[List[int]]) -> List[int | None]:
        result = []
        counter: RecentCounter = None
        for i, command in enumerate(commands):
            if command == "RecentCounter":
                counter = RecentCounter()
                result.append(None)
                continue

            if command == "ping":
                result.append(counter.ping(values[i][0]))

        return result

class RecentCounter:
    def __init__(self):
        self._queue = deque()

    def ping(self, t: int) -> int:
        self._queue.append(t)

        oldest = t - 3000
        while len(self._queue) > 0 and self._queue[0] < oldest:
            self._queue.popleft()

        return len(self._queue)



# Your RecentCounter object will be instantiated and called as such:
# obj = RecentCounter()
# param_1 = obj.ping(t)

if __name__ == '__main__':
    TestGen(NumberOfRecentCalls) \
        .Add(lambda tc: tc.Param(["RecentCounter","ping","ping","ping","ping"]).Param([[],[1],[100],[3001],[3002]]).Result([None,1,2,3,3]) ) \
        .Run()

