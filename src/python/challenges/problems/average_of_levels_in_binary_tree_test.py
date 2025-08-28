# https://leetcode.com/problems/average-of-levels-in-binary-tree

from typing import Optional
from core.problem_base import *
from models.tree_node import TreeNode

class AverageOfLevels(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> list[float]:
        queue = [(root, 0)]
        result = []

        while queue:
            node, level = queue.pop(0)

            if len(result) <= level:
                result.append([])

            result[level].append(node.val)

            if node.left:
                queue.append((node.left, level + 1))

            if node.right:
                queue.append((node.right, level + 1))

        return [sum(level) / len(level) for level in result]

if __name__ == '__main__':
    TestGen(AverageOfLevels) \
        .Add(lambda tc: tc.ParamTreeNode([3,9,20,None,None,15,7]).Result([3.00000,14.50000,11.00000])) \
        .Add(lambda tc: tc.ParamTreeNode([3,9,20,15,7]).Result([3.00000,14.50000,11.00000])) \
        .Run()
