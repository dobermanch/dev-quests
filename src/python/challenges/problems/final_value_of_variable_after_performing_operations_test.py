
# https://leetcode.com/problems/final-value-of-variable-after-performing-operations

from typing import List
from core.problem_base import *

class FinalValueOfVariableAfterPerformingOperations(ProblemBase):
    def Solution(self, operations: List[str]) -> int:
        operations_map = {
            "++X": 1,
            "X++": 1,
            "--X": -1,
            "X--": -1
        }

        X = 0
        for _, op in enumerate(operations):
            if op in operations_map:
                X += operations_map[op]

        return X

if __name__ == '__main__':
    TestGen(FinalValueOfVariableAfterPerformingOperations) \
        .Add(lambda tc: tc.Param(["--X","X++","X++"]).Result(1)) \
        .Add(lambda tc: tc.Param(["++X","++X","X++"]).Result(3)) \
        .Add(lambda tc: tc.Param(["X++","++X","--X","X--"]).Result(0)) \
        .Run()
