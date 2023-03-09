

class MinWindow:
    def Solution(self, s: str, t: str) -> str:
        mapT = {}

        for t1 in t:
            mapT[t1] = 1 + mapT.get(t1, 0)

        left = 0
        matches = 0
        pos = (0,float('inf'))
        mapS = {}
        for right in range(len(s)):
            mapS[s[right]] = 1 + mapS.get(s[right], 0)

            if s[right] in mapT and mapT[s[right]] >= mapS[s[right]]:
                matches += 1

            while matches == len(t):
                if right - left < pos[1] - pos[0]:
                    pos = (left, right)

                mapS[s[left]] -= 1
                if s[left] in mapT and mapT[s[left]] > mapS[s[left]]:
                    matches -= 1

                left += 1

        return "" if pos[1] > len(s) else s[pos[0]: pos[1] + 1]


MinWindow().Solution("ADOBECODEBANC", "ABC")