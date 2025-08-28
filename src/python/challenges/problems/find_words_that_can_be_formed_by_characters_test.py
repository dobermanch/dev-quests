# https://leetcode.com/problems/find-words-that-can-be-formed-by-characters

from core.problem_base import *

class CountCharacters(ProblemBase):
    def Solution(self, words: list[str], chars: str) -> int:
        charMap = {}

        for ch in chars:
            charMap[ch] = charMap.get(ch, 0) + 1

        result = 0
        for word in words:
            wordMap = {}
            matched = True

            for ch in word:
                wordMap[ch] = wordMap.get(ch, 0) + 1

                if ch not in charMap or wordMap[ch] > charMap[ch]:
                    matched = False
                    break

            if matched:
                result += len(word)

        return result

if __name__ == '__main__':
    TestGen(CountCharacters) \
        .Add(lambda tc: tc.Param(["cat","bt","hat","tree"]).Param("atach").Result(6)) \
        .Add(lambda tc: tc.Param(["hello","world","leetcode"]).Param("welldonehoneyr").Result(10)) \
        .Run()
