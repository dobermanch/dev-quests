# https://leetcode.com/problems/add-strings/

from core.problem_base import *

class AddStrings(ProblemBase):
    def Solution(self, num1: str, num2: str) -> str:
        length = max(len(num1), len(num2))

        diff = '0' * abs(len(num1) - len(num2))
        if len(num1) < len(num2):
            num1 = diff + num1
        else:
            num2 = diff + num2

        result = ""
        carry = 0
        for i in range(length - 1, -1, -1):
            sum = carry + int(num1[i]) + int(num2[i])
            carry = sum // 10
            result = str(sum % 10) + result

        return str(carry) + result if carry > 0 else result

if __name__ == '__main__':
    TestGen(AddStrings) \
        .Add(lambda tc: tc.Param("11").Param("123").Result("134")) \
        .Add(lambda tc: tc.Param("456").Param("77").Result("533")) \
        .Add(lambda tc: tc.Param("0").Param("0").Result("0")) \
        .Run()
