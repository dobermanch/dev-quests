# https://leetcode.com/problems/basic-calculator

from collections import defaultdict
from core.problem_base import *

class Calculate(ProblemBase):
    def Solution(self, s: str) -> int:
        numbers = []
        operand = 1
        number = 0
        result = 0
        for i in range(len(s)):
            if s[i].isdigit():
                number *= 10
                number += int(s[i])

            if not s[i].isdigit() or i == len(s) - 1:
                result += number * operand
                number = 0

            if s[i] == '(':
                numbers.append(result)
                numbers.append(operand)
                operand = 1
                result = 0
            elif s[i] == ')':
                result *= numbers.pop()
                result += numbers.pop()
            elif s[i] == '-':
                operand = -1
            elif s[i] == '+':
                operand = 1

        return result

if __name__ == '__main__':
    TestGen(Calculate) \
        .Add(lambda tc: tc.Param("1 + 1").Result(2)) \
        .Add(lambda tc: tc.Param(" 2-1 + 2 ").Result(3)) \
        .Add(lambda tc: tc.Param("(1+(4+5+2)-3)+(6+8)").Result(23)) \
        .Add(lambda tc: tc.Param("- (3 - (- (4 + 5) ) )").Result(-12)) \
        .Add(lambda tc: tc.Param(" 2-1 + 23").Result(24)) \
        .Run()
