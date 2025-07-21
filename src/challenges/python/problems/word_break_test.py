#https://leetcode.com/problems/word-break/
from core.problem_base import *

class WordBreak(ProblemBase):
    def Solution(self, s: str, wordDict: list[str]) -> bool:
        map = [False] * (len(s) + 1)
        map[len(s)] = True
        mem = [len(s)]
        for i in range(len(s) - 1, -1, -1):
            for j in range(len(mem) - 1, -1, -1):
                if s[i:mem[j]] in wordDict:
                    map[i] = map[mem[j]]
                    mem.append(i)
                    break

        return map[0]

if __name__ == '__main__':
    TestGen(WordBreak) \
        .Add(lambda tc: tc.Param("leetcode").Param(["leet","code"]).Result(True)) \
        .Add(lambda tc: tc.Param("applepenapple").Param(["apple","pen"]).Result(True)) \
        .Add(lambda tc: tc.Param("catsandog").Param(["cats","dog","sand","and","cat"]).Result(False)) \
        .Run()

