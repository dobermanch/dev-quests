
# https://leetcode.com/problems/word-ladder

from collections import deque
import string
from typing import List
from core.problem_base import *

class WordLadder(ProblemBase):
    def Solution(self, beginWord: str, endWord: str, wordList: List[str]) -> int:
        wordsSet = set(wordList)

        seen = set()
        queue = deque()
        queue.append((beginWord, 1))
        seen.add(beginWord)

        result = 0
        while queue:
            word, count = queue.popleft()

            if word == endWord:
                result = count
                break

            for l in string.ascii_lowercase:
                for i in range(len(beginWord)):
                    nextWord = word[:i] + l + word[i + 1:]
                    if nextWord not in seen and nextWord in wordsSet:
                        queue.append((nextWord, count + 1))
                        seen.add(nextWord)

        return result

if __name__ == '__main__':
    TestGen(WordLadder) \
        .Add(lambda tc: tc.Param("hit").Param("cog").Param(["hot","dot","dog","lot","log","cog"]).Result(5)) \
        .Add(lambda tc: tc.Param("hit").Param("cog").Param(["hot","dot","dog","lot","log"]).Result(0)) \
        .Run()
