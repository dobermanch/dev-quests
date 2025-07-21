# https://leetcode.com/problems/add-binary

from core.problem_base import *

class AddBinary(ProblemBase):
    def Solution(self, a: str, b: str) -> str:
        if len(a) > len(b):
            b = b.rjust(len(a), '0')
        else:
            a = a.rjust(len(b), '0')

        result = []
        carry = 0
        for i in range(len(a) - 1, -1, -1):
            temp = int(a[i]) + int(b[i]) + carry
            bit = str(temp % 2)
            carry = temp // 2
            result.insert(0, bit)

        if carry == 1:
            result.insert(0, '1')

        return ''.join(result)

if __name__ == '__main__':
    TestGen(AddBinary) \
        .Add(lambda tc: tc.Param("11").Param("1").Result("100")) \
        .Add(lambda tc: tc.Param("1010").Param("1011").Result("10101")) \
        .Add(lambda tc: tc.Param("1101010").Param("111").Result("1110001")) \
        .Run()
