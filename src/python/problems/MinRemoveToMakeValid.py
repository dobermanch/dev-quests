# https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
class MinRemoveToMakeValid:
    def Solution(self, s: str) -> str:
        stack = []
        result = list(s)
        for i, ch in enumerate(s):
            if ch == '(':
                stack.append(i)
            elif ch == ')' and len(stack) > 0:
                stack.pop()
            elif ch == ')':
                result[i] = ''

        while stack:
            result[stack.pop()] = ''

        return ''.join(result)


MinRemoveToMakeValid().Solution("babad")
