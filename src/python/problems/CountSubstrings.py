#https://leetcode.com/problems/palindromic-substrings/
class CountSubstrings:
    def Solution(self, s: str) -> int:
        def IsPalindrome(str, left, right):
            count = 0
            while left >= 0 and right < len(str):
                if str[left] != str[right]:
                    break
                count += 1
                left -= 1
                right += 1
            return count

        result = 0
        for i in range(len(s)):
            result += IsPalindrome(s, i, i)
            result += IsPalindrome(s, i, i + 1)

        return result


CountSubstrings().Solution("abaaba")
