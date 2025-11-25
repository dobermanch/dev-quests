
# https://leetcode.com/problems/asteroid-collision

from typing import List
from core.problem_base import *

class AsteroidCollision(ProblemBase):
    def Solution(self, asteroids: List[int]) -> List[int]:
        stack = []

        for i in range(len(asteroids)):
            add = True
            while len(stack) > 0 and asteroids[i] < 0 and stack[-1] > 0:
                if stack[-1] < -1 * asteroids[i]:
                    stack.pop()
                elif stack[-1] == -1 * asteroids[i]:
                    stack.pop()
                    add = False
                    break
                else:
                    add = False
                    break

            if add:
                stack.append(asteroids[i])

        return stack

if __name__ == '__main__':
    TestGen(AsteroidCollision) \
        .Add(lambda tc: tc.Param([5,10,-5]).Result([5,10])) \
        .Add(lambda tc: tc.Param([8,-8]).Result([])) \
        .Add(lambda tc: tc.Param([10,2,-5]).Result([10])) \
        .Add(lambda tc: tc.Param([3,5,-6,2,-1,4]).Result([-6,2,4])) \
        .Run()
