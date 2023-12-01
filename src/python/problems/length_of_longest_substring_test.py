#https://leetcode.com/problems/longest-substring-without-repeating-characters/

from core.problem_base import *

class LengthOfLongestSubstring(ProblemBase):
    def Solution(self, s: str) -> int:
        map = {}

        result = 0
        left = 0
        for right in range(len(s)):
            if s[right] not in map:
                result = max(result, right - left + 1)  
            else: 
                if map[s[right]] < left:
                    result = max(result, right - left + 1)
                else: 
                    left = map[s[right]] + 1
            map[s[right]] = right
                
        return result

if __name__ == '__main__':
    TestGen(LengthOfLongestSubstring) \
        .Add(lambda tc: tc.Param("abcabcbb").Result(3)) \
        .Add(lambda tc: tc.Param("bbbbb").Result(1)) \
        .Add(lambda tc: tc.Param("pwwkew").Result(3)) \
        .Run()
