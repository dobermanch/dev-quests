# https://leetcode.com/problems/longest-valid-parentheses

from heapq import heappop, heappush
from core.problem_base import *

class LongestValidParentheses(ProblemBase):
    def Solution(self, s: str) -> int:
        stack = [-1]
        result = 0
        for i in range(len(s)):
            if s[i] == '(':
                stack.append(i)
                continue

            stack.pop()
            if not stack:
                stack.append(i)
            else:
                result = max(result, i - stack[-1])

        return result

if __name__ == '__main__':
    TestGen(LongestValidParentheses) \
        .Add(lambda tc: tc.Param("s", "(()").Result(2)) \
        .Add(lambda tc: tc.Param("s", ")()())").Result(4)) \
        .Add(lambda tc: tc.Param("s", "").Result(0)) \
        .Add(lambda tc: tc.Param("s", "()(())").Result(6)) \
        .Run()
