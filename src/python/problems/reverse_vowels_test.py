# https://leetcode.com/problems/reverse-vowels-of-a-string

from core.problem_base import *

class ReverseVowels(ProblemBase):
    def Solution(self, s: str) -> str:
        map = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'}

        result = list(s)
        left = 0
        right = len(s) - 1
        while left < right:
            if s[left] in map:
                if s[right] in map:
                    result[left], result[right] = result[right], result[left]
                    left += 1
                right -= 1
            else:
                left += 1
        
        return ''.join(result)

if __name__ == '__main__':
    TestGen(ReverseVowels) \
        .Add(lambda tc: tc.Param("s", "hello").Result("holle")) \
        .Add(lambda tc: tc.Param("s", "leetcode").Result("leotcede")) \
        .Add(lambda tc: tc.Param("s", " ").Result(" ")) \
        .Run()

