#https://leetcode.com/problems/palindrome-number

from core.problem_base import *

class IsPalindromeNumber(ProblemBase):
    def Solution(self, x: int) -> bool:
        if x < 0:
            return False
        
        original = x
        reversed = 0
        while x > 0:
            reversed = reversed * 10 + x % 10
            x = x // 10
        
        return original == reversed                     
    
    def Solution1(self, x: int) -> bool:
        if x < 0:
            return False
        
        arr = []
        while x > 0:
            arr.append(x % 10)
            x = x // 10

        left = 0
        right = len(arr) - 1
        while left <= right:
            if arr[left] != arr[right]:
                return False

            left += 1
            right -= 1            
                
        return True

if __name__ == '__main__':
    TestGen(IsPalindromeNumber) \
        .Add(lambda tc: tc.Param(1221).Result(True)) \
        .Add(lambda tc: tc.Param(121).Result(True)) \
        .Add(lambda tc: tc.Param(-121).Result(False)) \
        .Add(lambda tc: tc.Param(10).Result(False)) \
        .Run()
