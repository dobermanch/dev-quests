#https://leetcode.com/problems/course-schedule/
from core.problem_base import *

class CanFinish(ProblemBase):
    def Solution(self, numCourses: int, prerequisites: list[list[int]]) -> bool:
        def Visit(dependencies, current, visited, cycle):
            if cycle[current]:
                return False

            if visited[current]:
                return True

            visited[current] = True
            cycle[current] = True

            for course in dependencies[current]:
                if course in dependencies and not Visit(dependencies, course, visited, cycle):
                    return False

            cycle[current] = False

            return True


        dependencies = {}
        for course, prereq in prerequisites:
            if course not in dependencies:
                dependencies[course] = []
            dependencies[course].append(prereq)

        visited = [False] * numCourses
        cycle = [False] * numCourses

        for course in dependencies:
            if not Visit(dependencies, course, visited, cycle):
                return False

        return True

if __name__ == '__main__':
    TestGen(CanFinish) \
        .Add(lambda tc: tc.Param(2).Param([[1,0]]).Result(True)) \
        .Add(lambda tc: tc.Param(2).Param([[1,0],[0,1]]).Result(False)) \
        .Run()
