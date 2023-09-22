# https://leetcode.com/problems/rotate-image/

class WordPattern:
    def Solution(self, pattern: str, s: str) -> bool:
        words = s.split(' ')
        if len(words) != len(pattern):
            return False

        map1 = {}
        map2 = {}

        for i in range(len(words)):
            word = words[i]
            pat = pattern[i]

            if pat not in map1 and word not in map2:
                map1[pat] = word
                map2[word] = pat
                continue

            if pat not in map1 or map1[pat] != word or word not in map2 or map2[word] != pat:
                return False

        return True


WordPattern().Solution("aaa", "dog cat dog")
