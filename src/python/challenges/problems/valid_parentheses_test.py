
# https://leetcode.com/problems/valid-parentheses

from typing import List
from core.problem_base import *

class ValidParentheses(ProblemBase):
    def Solution(self, s: str) -> bool:
        stack = []
        map = {
            '}': '{',
            ')': '(',
            ']': '[',
        }

        for ch in s:
            if ch in map:
                if not stack or stack[-1] != map[ch]:
                    return False
                stack.pop()
            else:
                stack.append(ch)

        return len(stack) == 0

if __name__ == '__main__':
    TestGen(ValidParentheses) \
        .Add(lambda tc: tc.Param("()").Result(True)) \
        .Add(lambda tc: tc.Param("()[]{}").Result(True)) \
        .Add(lambda tc: tc.Param("(]").Result(False)) \
        .Add(lambda tc: tc.Param("([])").Result(True)) \
        .Add(lambda tc: tc.Param("([)]").Result(False)) \
        .Run()

# Test cases
# "()"
# "()[]{}"
# "(]"
# "([])"
# "([)]"
