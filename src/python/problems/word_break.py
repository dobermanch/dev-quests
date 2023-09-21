#https://leetcode.com/problems/word-break/
class WordBreak:
    def Solution(self, s: str, wordDict: list[str]) -> bool:
        map = [False] * (len(s) + 1)
        map[len(s)] = True
        mem = [len(s)]
        for i in range(len(s) - 1, -1, -1):
            for j in range(len(mem) - 1, -1, -1):
                if s[i:mem[j]] in wordDict:
                    map[i] = map[mem[j]]
                    mem.append(i)
                    break

        return map[0]


WordBreak().Solution("leetcode", ["leet","code"])
