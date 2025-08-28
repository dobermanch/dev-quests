# https://leetcode.com/problems/integer-to-roman

from core.problem_base import *

class IntToRoman(ProblemBase):
    def Solution(self, num: int) -> str:
        map = {
            1: "I",
            5: "V",
            10: "X",
            50: "L",
            100: "C",
            500: "D",
            1000: "M"
        }

        result = ""
        acc = 1
        while num > 0:
            reminder = num % 10
            number = reminder * acc
            num //= 10

            if reminder <= 3:
                result = map[acc][0] * reminder + result
            elif reminder == 4:
                result = map[acc] + map[number + acc] + result
            elif 5 <= reminder <= 8:
                result = map[5 * acc] + map[acc][0] * (reminder - 5) + result
            elif reminder == 9:
                result = map[acc] + map[acc * 10] + result
            else:
                result = map[number] + result

            acc *= 10

        return result

if __name__ == '__main__':
    TestGen(IntToRoman) \
        .Add(lambda tc: tc.Param(3).Result("III")) \
        .Add(lambda tc: tc.Param(58).Result("LVIII")) \
        .Add(lambda tc: tc.Param(1994).Result("MCMXCIV")) \
        .Add(lambda tc: tc.Param(3490).Result("MMMCDXC")) \
        .Run()
