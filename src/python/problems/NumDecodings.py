#https://leetcode.com/problems/decode-ways/
class NumDecodings:
    def Solution(self, s: str) -> int:
        n = len(s)
        temp1 = 1
        temp2 = 1
        for i in range(n - 1, -1, -1):
            temp = temp1
            if s[i] == '0':
                temp1 = 0
            elif i + 1 < n and (s[i] == '1' or s[i] == '2' and s[i + 1] <= '6'):
                temp1 += temp2

            temp2 = temp

        return temp1


NumDecodings().Solution("1201234")
