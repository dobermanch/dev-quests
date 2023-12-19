# https://leetcode.com/problems/valid-palindrome

from core.problem_base import *

class IsPalindrome(ProblemBase):
    def Solution(self, s: str) -> bool:
        left = 0
        right = len(s) - 1
        while left < right:
            lRune = s[left]
            rRune = s[right]

            if not (lRune.isalpha() or lRune.isdigit()):
                left += 1
                continue

            if not (rRune.isalpha() or rRune.isdigit()):
                right -= 1
                continue

            if lRune.lower() != rRune.lower():
                return False

            left += 1
            right -= 1

        return True

if __name__ == '__main__':
    TestGen(IsPalindrome) \
        .Add(lambda tc: tc.Param("A man, a plan, a canal: Panama").Result(True)) \
        .Add(lambda tc: tc.Param("race a car").Result(False)) \
        .Add(lambda tc: tc.Param(" ").Result(True)) \
        .Run()
