#https://leetcode.com/problems/letter-combinations-of-a-phone-number

from collections import defaultdict
from core.problem_base import *

class LetterCombinations(ProblemBase):
    def Solution(self, digits: str) -> list[str]:
        if len(digits) <= 0:
            return []
        
        map = {
            '2':"abc", '3':"def",
            '4':"ghi", '5':"jkl", '6':"mno",
            '7':"pqrs", '8':"tuv", '9':"wxyz"
        }
        result = []
        temp = [0] * len(digits)
        def search(digitsIndex: int, tempIndex: int):
            if digitsIndex >= len(digits):
                result.append(''.join(temp))
                return
            
            for ch in map[digits[digitsIndex]]:
                temp[tempIndex] = ch
                search(digitsIndex + 1, tempIndex + 1)
        
        search(0, 0)

        return result
            

if __name__ == '__main__':
    TestGen(LetterCombinations) \
        .Add(lambda tc: tc.Param("23") .Result(["ad","ae","af","bd","be","bf","cd","ce","cf"])) \
        .Run()
