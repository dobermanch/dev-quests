#https://leetcode.com/problems/palindromic-substrings/

from core.problem_base import *
class CountSubstrings(ProblemBase):
    def Solution(self, s: str) -> int:
        def IsPalindrome(str, left, right):
            count = 0
            while left >= 0 and right < len(str):
                if str[left] != str[right]:
                    break
                count += 1
                left -= 1
                right += 1
            return count

        result = 0
        for i in range(len(s)):
            result += IsPalindrome(s, i, i)
            result += IsPalindrome(s, i, i + 1)

        return result
    
if __name__ == '__main__':
    TestGen(CountSubstrings) \
        .Add(lambda tc: tc.Param("abc").Result(3)) \
        .Add(lambda tc: tc.Param("aaa").Result(6)) \
        .Run()
