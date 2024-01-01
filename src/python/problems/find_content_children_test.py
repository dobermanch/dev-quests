# https://leetcode.com/problems/assign-cookies

from core.problem_base import *

class FindContentChildren(ProblemBase):
    def Solution(self, g: list[int], s: list[int]) -> int:
        g.sort()
        s.sort()

        cookie = 0
        green = 0
        result = 0
        while green < len(g) and cookie < len(s):
            if s[cookie] >= g[green]:
                result += 1
                green += 1

            cookie += 1

        return result

if __name__ == '__main__':
    TestGen(FindContentChildren) \
        .Add(lambda tc: tc.Param([1,2,3]).Param([1,1]).Result(1)) \
        .Add(lambda tc: tc.Param([1,2]).Param([1,2,3]).Result(2)) \
        .Add(lambda tc: tc.Param([10,9,8,7]).Param([5,6,7,8]).Result(2)) \
        .Run()
