# https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string

from core.problem_base import *

class MinOperations(ProblemBase):
    def Solution(self, s: str) -> int:
        operations = 0
        for i in range(len(s)):
            if i % 2 == 0 and s[i] != '1' \
                or i % 2 != 0 and s[i] == '1':
                operations += 1

        return min(operations, len(s) - operations)

if __name__ == '__main__':
    TestGen(MinOperations) \
        .Add(lambda tc: tc.Param("1111").Result(2)) \
        .Add(lambda tc: tc.Param("0100").Result(1)) \
        .Add(lambda tc: tc.Param("10").Result(0)) \
        .Run()
