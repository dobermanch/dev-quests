# https://leetcode.com/problems/partition-labels/
class PartitionLabels:
    def Solution(self, s: str) -> List[int]:
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


PartitionLabels().Solution("ababcbacadefegdehijhklij")
