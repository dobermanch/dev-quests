# https://leetcode.com/problems/simplify-path

from core.problem_base import *

class SimplifyPath(ProblemBase):
    def Solution(self, path: str) -> str:
        stack = []
        segment = ""

        for i in range(len(path)):
            if path[i] != '/':
                segment += path[i]

            if path[i] == '/' or i == len(path) - 1:
                dir = segment

                if dir == ".." and len(stack) > 0:
                    stack.pop()
                elif len(dir) > 0 and dir != "." and dir != "..":
                    stack.append(dir)

                segment = ""

        builder = ""
        if len(stack) <= 0:
            builder = "/"

        while len(stack) > 0:
            sub = stack.pop()
            builder = f"/{sub}" + builder

        return builder

if __name__ == '__main__':
    TestGen(SimplifyPath) \
        .Add(lambda tc: tc.Param("/home/").Result("/home")) \
        .Add(lambda tc: tc.Param("/../").Result("/")) \
        .Add(lambda tc: tc.Param("/home//foo/").Result("/home/foo")) \
        .Add(lambda tc: tc.Param("/home/../foo/").Result("/foo")) \
        .Add(lambda tc: tc.Param("/..hidden").Result("/..hidden")) \
        .Add(lambda tc: tc.Param("/a/./b/../../c/").Result("/a/./b/../../c/")) \
        .Run()
