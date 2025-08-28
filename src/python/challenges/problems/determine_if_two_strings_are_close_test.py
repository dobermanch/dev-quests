# https://leetcode.com/problems/determine-if-two-strings-are-close/

from core.problem_base import *
import collections

class CloseStrings(ProblemBase):
    def Solution(self, word1: str, word2: str) -> bool:
        if len(word1) != len(word2):
            return False
        
        map1 = collections.Counter(word1)
        map2 = collections.Counter(word2)

        if len(map1) != len(map2):
            return False

        for key in map1.keys():
            if key not in map2:
                return False
        
        occ1 = sorted(map1.values())
        occ2 = sorted(map2.values())

        return occ1 == occ2


if __name__ == '__main__':
    TestGen(CloseStrings) \
        .Add(lambda tc: tc.Param("abc").Param("bca").Result(True)) \
        .Add(lambda tc: tc.Param("a").Param("a").Result(True)) \
        .Add(lambda tc: tc.Param("a").Param("aa").Result(False)) \
        .Add(lambda tc: tc.Param("cabbba").Param("abbccc").Result(True)) \
        .Add(lambda tc: tc.Param("abbzzca").Param("babzzcz").Result(False)) \
        .Run()
