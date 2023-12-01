#https://leetcode.com/problems/generate-parentheses/
from core.problem_base import *

class GenerateParenthesis(ProblemBase):
    def Solution(self, n: int) -> list[str]:
        result = []
        def Build(open, closed, parenthesis, temp):
            temp += parenthesis

            if open > 0:
                Build(open - 1, closed, '(', temp)

            if closed > open:
                Build(open, closed - 1, ')', temp)

            if open == 0 and closed == 0:
                result.append(temp)

            temp = temp[:-1]

        Build(n - 1, n, '(', "")
        return result


if __name__ == '__main__':
    TestGen(GenerateParenthesis) \
        .Add(lambda tc: tc.Param(3).Result(["((()))","(()())","(())()","()(())","()()()"])) \
        .Add(lambda tc: tc.Param(1).Result(["()"])) \
        .Run()
