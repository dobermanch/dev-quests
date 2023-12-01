#https://leetcode.com/problems/removing-stars-from-a-string

from core.problem_base import *

class CanJump(ProblemBase):
    def Solution(self, s: str) -> str:
        stack = []
        for ch in s:
            if ch == '*':
                stack.pop()
            else:
                stack.append(ch)
        
        return "".join(stack)

if __name__ == '__main__':
    TestGen(CanJump) \
        .Add(lambda tc: tc.Param("leet**cod*e").Result("lecoe")) \
        .Add(lambda tc: tc.Param("erase*****").Result("")) \
        .Run()
