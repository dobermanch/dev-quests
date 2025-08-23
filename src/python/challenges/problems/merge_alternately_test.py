#https://leetcode.com/problems/merge-strings-alternately/

from core.problem_base import *

class MergeAlternately(ProblemBase):
    def Solution(self, word1: str, word2: str) -> str:
        result = ""

        word1Length = len(word1)
        word2Length = len(word2)
        length = word1Length if word1Length > word2Length else word2Length

        for i in range(length):
            if i < word1Length:
                result += word1[i]
            
            if i < word2Length:
                result += word2[i]

        return result

if __name__ == '__main__':
    TestGen(MergeAlternately) \
        .Add(lambda tc: tc.Param("abc").Param("pqr").Result("apbqcr")) \
        .Add(lambda tc: tc.Param("ab").Param("pqrs").Result("apbqrs")) \
        .Add(lambda tc: tc.Param("abcd").Param("pq").Result("apbqcd")) \
        .Run()
