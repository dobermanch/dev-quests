
# https://leetcode.com/problems/decode-string

from typing import List
from core.problem_base import *

class DecodeString(ProblemBase):
    def Solution(self, s: str) -> str:
        stack = [[0, ""]]

        times = 0
        for i in range(len(s)):
            if s[i] in "0123456789":
                times = times * 10 + int(s[i])
            elif s[i] == '[':
                stack.append([times, ""])
                times = 0
            elif s[i] == ']':
                temp = stack[-1][0] * stack[-1][1]
                stack.pop()
                stack[-1][1] += temp
            else:
                stack[-1][1] += s[i]

        return stack[-1][1]

if __name__ == '__main__':
    TestGen(DecodeString) \
        .Add(lambda tc: tc.Param("ab3[a2[c]]").Result("abaccaccacc")) \
        .Add(lambda tc: tc.Param("3[a]2[bc]").Result("aaabcbc")) \
        .Add(lambda tc: tc.Param("3[a2[c]]").Result("accaccacc")) \
        .Add(lambda tc: tc.Param("2[abc]3[cd]ef").Result("abcabccdcdcdef")) \
        .Run()

