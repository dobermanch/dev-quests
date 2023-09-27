#https://leetcode.com/problems/string-compression/

from heapq import heappop, heappush
from core.problem_base import *

class Compress(ProblemBase):
    def Solution(self, chars: list[str]) -> int:
        def compress(data, index, current, count):
            data[index] = current
            index += 1
            if count > 1:
                for ch in list(str(count)):
                    data[index] = ch
                    index += 1

            return index

        left = 0
        right = 1
        current = chars[0]
        count = 1
        while right < len(chars):
            if chars[right] == current:
                count += 1
                right += 1
                continue

            left = compress(chars, left, current, count)
            current = chars[right]
            count = 1
            right += 1

        return compress(chars, left, current, count)

if __name__ == '__main__':
    TestGen(Compress) \
        .Add(lambda tc: tc.Param("chars", ["a","a","b","b","c","c","c"]).Result(6)) \
        .Add(lambda tc: tc.Param("chars", ["a"]).Result(1)) \
        .Add(lambda tc: tc.Param("chars", ["a","b","b","b","b","b","b","b","b","b","b","b","b"]).Result(4)) \
        .Run()
