#https://leetcode.com/problems/reverse-words-in-a-string

from core.problem_base import *

class ReverseWords(ProblemBase):
    def Solution(self, s: str) -> str:
        result = ""

        left = 0
        right = 0
        length = len(s)

        while right <= length:
            if right < length and s[right] != ' ':
                right += 1
                continue

            if left != right:
                if len(result) > 0:
                    result = " " + result
                
                result = s[left:right] + result
            
            right += 1
            left = right

        return result
        

if __name__ == '__main__':
    TestGen(ReverseWords) \
        .Add(lambda tc: tc.Param("s", "the sky is blue").Result("blue is sky the")) \
        .Add(lambda tc: tc.Param("s", "  hello world  ").Result("world hello")) \
        .Add(lambda tc: tc.Param("s", "a good   example").Result("example good a")) \
        .Run()
