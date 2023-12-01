# https://leetcode.com/problems/n-ary-tree-preorder-traversal/
from models.node import Node
from core.problem_base import *

class Preorder(ProblemBase):
    def Solution(self, root: 'Node') -> list[int]:
        if not root:
            return []

        result = []
        stack = []
        stack.append(root)
        while stack:
            current = stack.pop()
            result.append(current.val)

            for i in range(len(current.children) - 1, -1, -1):
                stack.append(current.children[i])

        return result

if __name__ == '__main__':
    node1 = Node(1)
    node3 = Node(3)
    node1.children.append(node3)
    node1.children.append(Node(2))
    node1.children.append(Node(4))
    node3.children.append(Node(5))
    node3.children.append(Node(6))
    TestGen(Preorder) \
        .Add(lambda tc: tc.Param(node1).Result([1,3,5,6,2,4])) \
        .Run()
