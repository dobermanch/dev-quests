# https://leetcode.com/problems/count-complete-tree-nodes

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class CountNodes(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        def Count(root):
            if not root:
                return 0

            node = root
            leftDepth = 0
            while node:
                node = node.left
                leftDepth += 1

            node = root
            rightDepth = 0
            while node:
                node = node.right
                rightDepth += 1

            if leftDepth == rightDepth:
                return 2 ** leftDepth - 1

            return 1 + Count(root.left) + Count(root.right)

        return Count(root)

if __name__ == '__main__':
    TestGen(CountNodes) \
        .Add(lambda tc: tc.Param([1,2,3,4,5,6]).Result(6)) \
        .Add(lambda tc: tc.Param([]).Result(0)) \
        .Add(lambda tc: tc.Param([1]).Result(1)) \
        .Run()
