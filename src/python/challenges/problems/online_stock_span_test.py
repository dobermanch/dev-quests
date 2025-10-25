
# https://leetcode.com/problems/online-stock-span

from typing import List
from core.problem_base import *

class OnlineStockSpan(ProblemBase):
    def Solution(self, commands: list[int], values: list[list[int]]) -> list[int]:
        result = []

        spanner: StockSpanner = None
        for i, command in enumerate(commands):
            if command == "StockSpanner":
                spanner = StockSpanner()
                result.append(None)
                continue

            if command == "next":
                result.append(spanner.next(values[i][0]))

        return result

class StockSpanner:

    def __init__(self):
        self._stack = []

    def next(self, price: int) -> int:
        count = 1
        while self._stack and self._stack[-1][1] <= price:
            count += self._stack.pop()[0]

        self._stack.append((count, price))

        return count

if __name__ == '__main__':
    TestGen(OnlineStockSpan) \
        .Add(lambda tc: tc.Param(["StockSpanner","next","next","next","next","next","next","next"]).Param([[],[100],[80],[60],[70],[60],[75],[85]]).Result([None,1,1,1,2,1,4,6])) \
        .Run()
