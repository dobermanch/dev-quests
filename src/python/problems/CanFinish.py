#https://leetcode.com/problems/course-schedule/
class CanFinish:
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



CanFinish().Solution(5, [[1,4],[2,4],[3,1],[3,2]])
