# https://leetcode.com/problems/partition-labels/
from core.problem_base import *

class PartitionLabels(ProblemBase):
    def Solution(self, s: str) -> list[int]:
        result = []
        map = {}

        for i in range(len(s)):
            map[s[i]] = i

        right = 0
        length = 0

        for left in range(len(s)):
            length += 1

            if map[s[left]] > right:
                right = map[s[left]]
            
            if left == right:
                result.append(length)
                length = 0

        return result

if __name__ == '__main__':
    TestGen(PartitionLabels) \
        .Add(lambda tc: tc.Param("ababcbacadefegdehijhklij").Result([9,7,8])) \
        .Add(lambda tc: tc.Param("eccbbbbdec").Result([10])) \
        .Run()

