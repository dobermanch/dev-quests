
# https://leetcode.com/problems/smallest-number-in-infinite-set

from typing import List
from core.problem_base import *

class SmallestNumberInInfiniteSet(ProblemBase):
    def Solution(self, commands: List[str], values: List[List[int]]) -> List[int]:
        result = []
        set : SmallestInfiniteSet = None

        for i, command in enumerate(commands):
            if command == "SmallestInfiniteSet":
                set = SmallestInfiniteSet()
                result.append(None)
            elif command == "addBack":
                set.addBack(values[i][0])
                result.append(None)
            elif command == "popSmallest":
                result.append(set.popSmallest())

        return result

class SmallestInfiniteSet:
    def __init__(self):
        self._current = 1
        self._popped = set()

    def popSmallest(self) -> int:
        while self._current in self._popped:
            self._current += 1

        num = self._current
        self._popped.add(num)
        self._current += 1
        return num

    def addBack(self, num: int) -> None:
        if num not in self._popped:
            return

        self._popped.remove(num)

        if num < self._current:
            self._current = num

if __name__ == '__main__':
    TestGen(SmallestNumberInInfiniteSet) \
        .Add(lambda tc: tc.Param(["SmallestInfiniteSet","addBack","popSmallest","popSmallest","popSmallest","addBack","popSmallest","popSmallest","popSmallest"]).Param([[],[2],[],[],[],[1],[],[],[]]).Result([None,None,1,2,3,None,1,4,5]) ) \
        .Run()

