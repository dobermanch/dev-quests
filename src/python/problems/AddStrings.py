# https://leetcode.com/problems/add-strings/

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class AddStrings:
    def Solution(self, num1: str, num2: str) -> list[list[int]]:
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



AddStrings().Solution("154", "12")
