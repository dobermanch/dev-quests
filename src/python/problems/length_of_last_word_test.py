# https://leetcode.com/problems/length-of-last-word

from core.problem_base import *

class LengthOfLastWord(ProblemBase):
    def Solution(self, s: str) -> int:
        startAt = -1
        endAt = -1
        for i in range(len(s) - 1, -1, -1):
            if startAt == -1 and s[i] >= 'A':
                startAt = i
            elif startAt != -1 and s[i] == ' ':
                endAt = i
                break

        return startAt - endAt

if __name__ == '__main__':
    TestGen(LengthOfLastWord) \
        .Add(lambda tc: tc.Param("Hello World").Result(5)) \
        .Add(lambda tc: tc.Param("   fly me   to   the moon  ").Result(4)) \
        .Add(lambda tc: tc.Param("luffy is still joyboy").Result(6)) \
        .Run()
