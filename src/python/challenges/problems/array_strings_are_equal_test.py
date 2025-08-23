# https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent

from core.problem_base import *

class ArrayStringsAreEqual(ProblemBase):
    def Solution1(self, word1: list[str], word2: list[str]) -> bool:        
        return "".join(word1) == "".join(word2)
    
    def Solution2(self, word1: list[str], word2: list[str]) -> bool:
        def build(words):
            builder = ""
            for word in words:
                builder += word

            return builder

        return build(word1) == build(word2)

if __name__ == '__main__':
    TestGen(ArrayStringsAreEqual) \
        .Add(lambda tc: tc.Param(["ab", "c"]).Param(["a", "bc"]).Result(True)) \
        .Add(lambda tc: tc.Param(["a", "cb"]).Param(["ab", "c"]).Result(False)) \
        .Add(lambda tc: tc.Param(["abc", "d", "defg"]).Param(["abcddefg"]).Result(True)) \
        .Run()
