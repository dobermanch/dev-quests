# https://leetcode.com/problems/text-justification

from core.problem_base import *

class FullJustify(ProblemBase):
    def Solution(self, words: list[str], maxWidth: int) -> list[str]:
        result = []

        length = -1
        left = 0
        right = 0
        while right < len(words):
            length += len(words[right]) + 1

            if right + 1 < len(words) and length + 1 + len(words[right + 1]) <= maxWidth:
                right += 1
                continue

            intervals = right - left
            remain = 0
            spaces = 1
            if right < len(words) - 1 and intervals > 0:
                spaces = maxWidth - (length - intervals)
                remain = spaces % intervals
                spaces = spaces // intervals

            builder = words[left]
            for i in range(left + 1, left + intervals + 1):
                builder += " " * (spaces + (1 if remain > 0 else 0))
                builder += words[i]
                remain -= 1

            builder += " " * (maxWidth - len(builder))

            result.append(builder)
            right += 1
            left = right
            length = -1

        return result

if __name__ == '__main__':
    TestGen(FullJustify) \
        .Add(lambda tc: tc.Param(["This", "is", "an", "example", "of", "text", "justification."]).Param(16).Result(["This    is    an", "example  of text", "justification.  "])) \
        .Add(lambda tc: tc.Param(["What","must","be","acknowledgment","shall","be"]).Param(16).Result(["What   must   be", "acknowledgment  ", "shall be        "])) \
        .Add(lambda tc: tc.Param(["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"]).Param(20).Result(["Science  is  what we","understand      well","enough to explain to","a  computer.  Art is","everything  else  we","do                  "])) \
        .Run()
