
# https://leetcode.com/problems/minimum-genetic-mutation

from typing import List
from collections import deque
from core.problem_base import *

class MinimumGeneticMutation(ProblemBase):
    def Solution(self, startGene: str, endGene: str, bank: List[str]) -> int:
        seen = {}
        queue = deque([(endGene, len(endGene) - 1, 0)])

        result = -1
        while queue:
            gene, index, count = queue.popleft()

            if gene == startGene:
                result = count
                break

            if gene not in bank:
                continue

            if gene in seen:
                index -= 1
            else:
                count += 1
                index = len(endGene) - 1
                seen[gene] = count

            for l in ['A', 'C', 'G', 'T']:
                queue.append((gene[:index] + l + gene[index + 1:], index, seen[gene]))

        return result

if __name__ == '__main__':
    TestGen(MinimumGeneticMutation) \
        .Add(lambda tc: tc.Param("AAAAAAAA").Param("AAAAACGG").Param(["AAAAAAGA","AAAAAGGA","AAAAACGA","AAAAACGG","AAAAAAGG","AAAAAAGC"]).Result(3)) \
        .Add(lambda tc: tc.Param("AAAAAAAA").Param("CCCCCCCC").Param(["AAAAAAAA","AAAAAAAC","AAAAAACC","AAAAACCC","AAAACCCC","AACACCCC","ACCACCCC","ACCCCCCC","CCCCCCCA","CCCCCCCC"]).Result(8)) \
        .Add(lambda tc: tc.Param("AACCGGTT").Param("AACCGCTA").Param(["AACCGGTA","AACCGCTA","AAACGGTA"]).Result(2)) \
        .Add(lambda tc: tc.Param("AACCGGTT").Param("AAACGGTA").Param(["AACCGGTA","AACCGCTA","AAACGGTA"]).Result(2)) \
        .Add(lambda tc: tc.Param("AAAAAAAA").Param("CCCCCCCC").Param(["AAAAAAAA","AAAAAAAC","AAAAAACC","AAAAACCC","AAAACCCC","AACACCCC","ACCACCCC","ACCCCCCC","CCCCCCCA"]).Result(-1)) \
        .Add(lambda tc: tc.Param("AACCGGTT").Param("AACCGGTA").Param(["AACCGGTA"]).Result(1)) \
        .Run()
