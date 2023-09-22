#https://leetcode.com/problems/sort-characters-by-frequency/
from collections import Counter
from heapq import heappush, heappop

class FrequencySort:
    def Solution(self, s: str) -> str:
        map = Counter(s)

        queue = []
        for ch, count in map.items():
            heappush(queue, (-count, ch))

        result = ""
        while queue:
            count, ch = heappop(queue)
            result += ch * -count

        return result
    
    def Solution1(self, s: str) -> str:
        map = {}
        maxCount = 0
        for ch in s:
            map[ch] = map.get(ch, 0) + 1
            maxCount = max(maxCount, map[ch])

        buckets = [''] * (maxCount + 1)
        for ch, count in map.items():
            buckets[count] += ch * count

        result = ""
        for i in range(len(buckets) - 1, -1, -1):
            result += buckets[i]

        return result


FrequencySort().Solution1("tree")
