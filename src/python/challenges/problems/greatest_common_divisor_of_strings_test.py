#https://leetcode.com/problems/greatest-common-divisor-of-strings

from core.problem_base import *

class GcdOfStrings(ProblemBase):
    def Solution1(self, str1: str, str2: str) -> str:
        result = str2
        while len(result) > 0:
            if str1.replace(result, "") == "" and str2.replace(result, "") == "":
                return result
            
            result = result[:-1]
        
        return ""
    
    def Solution2(self, str1: str, str2: str) -> str:
        if not (str1 + str2 == str2 + str1):
            return ""

        def gcd(left, right):
            if right == 0:
                return left
            return gcd(right, left % right)
        
        return str1[:gcd(len(str1), len(str2))]
    
    def Solution3(self, str1: str, str2: str) -> str:
        if str1 + str2 != str2 + str1:
            return ""

        left = len(str1)
        right = len(str2)

        while right > 0:
            temp = left % right
            left = right
            right = temp

        return str2[:left]

if __name__ == '__main__':
    TestGen(GcdOfStrings) \
        .Add(lambda tc: tc.Param("ABCABC").Param("ABC").Result("ABC")) \
        .Add(lambda tc: tc.Param("ABABAB").Param("ABAB").Result("AB")) \
        .Add(lambda tc: tc.Param("ABAB").Param("CODE").Result("")) \
        .Add(lambda tc: tc.Param("TAUXXTAUXXTAUXXTAUXXTAUXX").Param("TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX").Result("TAUXX")) \
        .Run()
