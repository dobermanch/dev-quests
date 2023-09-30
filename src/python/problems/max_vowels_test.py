#https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/

from core.problem_base import *

class MaxVowels(ProblemBase):
    def Solution(self, s: str, k: int) -> int:
        map = {'a', 'e', 'i', 'o', 'u'}
        right = 0
        result = 0
        count = 0
        while right < len(s):
            if s[right] in map:
                count += 1
                result = max(result, count)

            left = right - k + 1
            if left >= 0 and s[left] in map:
                count -= 1
            
            right += 1

        return result

if __name__ == '__main__':
    TestGen(MaxVowels) \
        .Add(lambda tc: tc.Param("s", "abciiidef").Param(3).Result(3)) \
        .Add(lambda tc: tc.Param("s", "aeiou").Param(2).Result(2)) \
        .Add(lambda tc: tc.Param("s", "leetcode").Param(3).Result(2)) \
        .Run()
