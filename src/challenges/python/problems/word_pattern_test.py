# https://leetcode.com/problems/word-pattern
from core.problem_base import *

class WordPattern(ProblemBase):
    def Solution(self, pattern: str, s: str) -> bool:
        words = s.split(' ')
        if len(words) != len(pattern):
            return False

        map1 = {}
        map2 = {}

        for i in range(len(words)):
            word = words[i]
            pat = pattern[i]

            if pat not in map1 and word not in map2:
                map1[pat] = word
                map2[word] = pat
                continue

            if pat not in map1 or map1[pat] != word or word not in map2 or map2[word] != pat:
                return False

        return True

if __name__ == '__main__':
    TestGen(WordPattern) \
        .Add(lambda tc: tc.Param("abba").Param("dog cat cat dog").Result(True)) \
        .Add(lambda tc: tc.Param("abba").Param("dog cat cat fish").Result(False)) \
        .Add(lambda tc: tc.Param("aaaa").Param("dog cat cat dog").Result(False)) \
        .Run()

