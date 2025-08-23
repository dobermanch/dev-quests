# https://leetcode.com/problems/is-subsequence

from core.problem_base import *

class IsSubsequence(ProblemBase):
    def Solution(self, s: str, t: str) -> bool:
        if not s:
            return True

        if not t:
            return False

        j = 0
        for i in range(len(t)):
            if t[i] == s[j]:
                j += 1
                if j >= len(s):
                    break

        return j == len(s)

if __name__ == '__main__':
    TestGen(IsSubsequence) \
        .Add(lambda tc: tc.Param("abc").Param("ahbgdc").Result(True)) \
        .Add(lambda tc: tc.Param("axc").Param("ahbgdc").Result(False)) \
        .Run()
