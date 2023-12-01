# https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal

import collections
from typing import Optional
from models.tree_node import TreeNode
from core.problem_base import *

class ZigzagLevelOrder(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> list[list[int]]:
        if not root:
            return []

        result = []
        queue = collections.deque()
        queue.append((root, 0))

        while queue:
            node, level = queue.popleft()

            if len(result) == level:
                result.append([])
            
            if level % 2 == 0:
                result[level].append(node.val)
            else:
                result[level].insert(0, node.val)

            if node.left:
                queue.append((node.left, level + 1))
            
            if node.right:
                queue.append((node.right, level + 1))

        return result

if __name__ == '__main__':
    TestGen(ZigzagLevelOrder) \
        .Add(lambda tc: tc.ParamTreeNode([3,9,20,None,None,15,7]).Result([[3],[20,9],[15,7]])) \
        .Add(lambda tc: tc.ParamTreeNode([1]).Result([[1]])) \
        .Add(lambda tc: tc.ParamTreeNode([]).Result([])) \
        .Run()
