#https://leetcode.com/problems/find-smallest-letter-greater-than-target

from core.problem_base import *

class NextGreatestLetter(ProblemBase):
    def Solution(self, letters: list[str], target: str) -> str:
        left = 0
        right = len(letters) - 1

        while left <= right:
            mid = (left + right) // 2

            if letters[mid] > target:
                right = mid - 1
            else:
                left = mid + 1

        return letters[left] if left < len(letters) else letters[0]


if __name__ == '__main__':
    TestGen(NextGreatestLetter) \
        .Add(lambda tc: tc.Param(["e","e","e","e","e","e","n","n","n","n"]).Param("e").Result("n")) \
        .Add(lambda tc: tc.Param(["c","f","j"]).Param("a").Result("c")) \
        .Add(lambda tc: tc.Param(["c","f","j"]).Param("c").Result("f")) \
        .Add(lambda tc: tc.Param(["x","x","y","y"]).Param("z").Result("x")) \
        .Run()
