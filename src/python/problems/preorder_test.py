# https://leetcode.com/problems/n-ary-tree-preorder-traversal/
from models.node import Node
from core.problem_base import *

class Preorder(ProblemBase):
    def Solution(self, root: 'Node') -> list[int]:
        result = []
        stack = []
        stack.append(root)
        while len(stack) > 0:
            current = stack.pop()
            result.append(current.val)

            for i in range(len(current.children) - 1, 0, -1):
                stack.append(current.children[i])

        return result

if __name__ == '__main__':
    # TestGen(Preorder) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    Preorder().Solution(Node(1, [Node(2), Node(3, [Node(6), Node(7, [Node(11)])])]))
