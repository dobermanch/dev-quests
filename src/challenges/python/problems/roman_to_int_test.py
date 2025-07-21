# https://leetcode.com/problems/roman-to-integer

from core.problem_base import *

class RomanToInt(ProblemBase):
    def Solution(self, s: str) -> int:
        map = { 
            'I': 1,
            'V': 5,
            'L': 50,
            'X': 10,
            'C': 100,
            'D': 500,
            'M': 1000,
        }

        result = 0
        for i in range(len(s)):
            if i + 1 < len(s) and map[s[i]] < map[s[i + 1]]:
                result -= map[s[i]] 
            else:
                result += map[s[i]]

        return result

if __name__ == '__main__':
    TestGen(RomanToInt) \
        .Add(lambda tc: tc.Param("III").Result(3)) \
        .Add(lambda tc: tc.Param("LVIII").Result(58)) \
        .Add(lambda tc: tc.Param("MCMXCIV").Result(1994)) \
        .Add(lambda tc: tc.Param("MMMCDXC").Result(3490)) \
        .Run()
