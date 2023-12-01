# https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
from core.problem_base import *

class MinRemoveToMakeValid(ProblemBase):
    def Solution(self, s: str) -> str:
        stack = []
        result = list(s)
        for i, ch in enumerate(s):
            if ch == '(':
                stack.append(i)
            elif ch == ')' and len(stack) > 0:
                stack.pop()
            elif ch == ')':
                result[i] = ''

        while stack:
            result[stack.pop()] = ''

        return ''.join(result)

if __name__ == '__main__':
    TestGen(MinRemoveToMakeValid) \
        .Add(lambda tc: tc.Param("lee(t(c)o)de)").Result("lee(t(c)o)de")) \
        .Add(lambda tc: tc.Param("a)b(c)d").Result("ab(c)d")) \
        .Add(lambda tc: tc.Param("))((").Result("")) \
        .Run()
