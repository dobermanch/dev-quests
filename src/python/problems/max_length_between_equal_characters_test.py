# https://leetcode.com/problems/largest-substring-between-two-equal-characters

from core.problem_base import *

class MaxLengthBetweenEqualCharacters(ProblemBase):
    def Solution(self, s: str) -> int:
        map = {}

        result = -1
        for i in range(len(s)):
            if s[i] in map:
                result = max(result, i - map[s[i]] - 1)
            else:
                map[s[i]] = i

        return result

if __name__ == '__main__':
    TestGen(MaxLengthBetweenEqualCharacters) \
        .Add(lambda tc: tc.Param("aa").Result(0)) \
        .Add(lambda tc: tc.Param("abca").Result(2)) \
        .Add(lambda tc: tc.Param("cbzxy").Result(-1)) \
        .Run()
