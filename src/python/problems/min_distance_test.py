#https://leetcode.com/problems/edit-distance

from core.problem_base import *

class MinDistance(ProblemBase):
    def Solution(self, word1: str, word2: str) -> int:
        map = [[0] * (len(word2) + 1) for _ in range(len(word1) + 1)]

        for i in range(len(word1) + 1):
            map[i][0] = i
        
        for i in range(len(word2) + 1):
            map[0][i] = i

        for i in range(1, len(word1) + 1):
            for j in range(1, len(word2) + 1):
                add = 0 if word1[i - 1] == word2[j - 1] else 1
                map[i][j] = min(map[i - 1][j] + 1, map[i][j - 1] + 1, map[i - 1][j - 1] + add)

        return map[-1][-1]

if __name__ == '__main__':
    TestGen(MinDistance) \
        .Add(lambda tc: tc.Param("word1", "horse").Param("word2", "ros").Result(3)) \
        .Add(lambda tc: tc.Param("word1", "intention").Param("word2", "execution").Result(5)) \
        .Run()
