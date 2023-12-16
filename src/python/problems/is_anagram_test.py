# https://leetcode.com/problems/valid-anagram

from core.problem_base import *

class IsAnagram(ProblemBase):
    def Solution(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False

        map = {}
        for i in range(len(s)):
            map[s[i]] = map.get(s[i], 0) + 1
            map[t[i]] = map.get(t[i], 0) - 1

        for _, v in map.items():
            if v != 0:
                return False

        return True

if __name__ == '__main__':
    TestGen(IsAnagram) \
        .Add(lambda tc: tc.Param("anagram").Param("nagaram").Result(True)) \
        .Add(lambda tc: tc.Param("rat").Param("cat").Result(False)) \
        .Run()
