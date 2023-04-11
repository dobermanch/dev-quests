#https://leetcode.com/problems/generate-parentheses/
class GenerateParenthesis:
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


GenerateParenthesis().Solution([9,10,9,-7,-4,-8,2,-6], 5)
