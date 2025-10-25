
# https://leetcode.com/problems/binary-tree-right-side-view

from collections import deque
from typing import List, Optional
from core.problem_base import *
from models.tree_node import TreeNode

class BinaryTreeRightSideView(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> List[int]:
        if not root:
            return []

        result = []
        queue = deque()
        queue.append((0, root))

        while len(queue) > 0:
            level, node = queue.popleft()

            if len(result) == level:
                result.append(node.val)

            if node.right:
                queue.append((level + 1, node.right))

            if node.left:
                queue.append((level + 1, node.left))

        return result

if __name__ == '__main__':
    TestGen(BinaryTreeRightSideView) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3,None,5,None,4]).Result([1,3,4]) ) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3,4,None,None,None,5]).Result([1,3,4,5])) \
        .Add(lambda tc: tc.ParamTreeNode([1,None,3]).Result([1,3])) \
        .Add(lambda tc: tc.ParamTreeNode([]).Result([])) \
        .Run()

