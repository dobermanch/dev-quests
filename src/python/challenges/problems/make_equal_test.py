# https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal

from core.problem_base import *

class MakeEqual(ProblemBase):
    def Solution(self, words: list[str]) -> bool:
        map = [0] * 26

        for word in words:
            for ch in word:
                map[ord(ch) - ord('a')] += 1

        length = len(words)
        for count in map:
            if count % length != 0:
                return False

        return True

if __name__ == '__main__':
    TestGen(MakeEqual) \
        .Add(lambda tc: tc.Param(["abc","aabc","bc"]).Result(True)) \
        .Add(lambda tc: tc.Param(["ab","a"]).Result(False)) \
        .Add(lambda tc: tc.Param(["a","b"]).Result(False)) \
        .Run()
