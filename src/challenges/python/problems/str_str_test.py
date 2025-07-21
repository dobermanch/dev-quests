# https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string

from core.problem_base import *

class StrStr(ProblemBase):
    def Solution(self, haystack: str, needle: str) -> int:
        length = len(haystack) - len(needle) + 1
        for index in range(length):
            if haystack[index] != needle[0]:
                continue

            left = 0
            right = len(needle) - 1
            while left <= right \
                and haystack[index+left] == needle[left] \
                and haystack[index+right] == needle[right]:
                left += 1
                right -= 1

            if left > right:
                return index

        return -1

if __name__ == '__main__':
    TestGen(StrStr) \
        .Add(lambda tc: tc.Param("sadbutsad").Param("sad").Result(0)) \
        .Add(lambda tc: tc.Param("leetcode").Param("leeto").Result(-1)) \
        .Add(lambda tc: tc.Param("a").Param("a").Result(0)) \
        .Run()
