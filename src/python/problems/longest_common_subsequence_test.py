#https://leetcode.com/problems/longest-common-subsequence/
class LongestCommonSubsequence:
    def Solution(self, text1: str, text2: str) -> int:
        map = [[0 for i in range(len(text2) + 1)] for j in range(len(text1) + 1)]
        for i in range(len(text1) - 1, -1, -1):
            for j in range(len(text2) - 1, -1, -1):
                if text1[i] == text2[j]:
                    map[i][j] = map[i + 1][j + 1] + 1
                else:
                    map[i][j] = max(map[i][j + 1], map[i + 1][j])

        return map[0][0]



LongestCommonSubsequence().Solution("abcde", "ace")
