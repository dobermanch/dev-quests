
# https://leetcode.com/problems/maximum-width-of-binary-tree

from collections import deque
from typing import List
from core.problem_base import *
from models.tree_node import TreeNode

class MaximumWidthOfBinaryTree(ProblemBase):
    def Solution(self, root: TreeNode | None) -> int:
        if not root:
            return 0

        queue = deque()
        queue.append((root, 0))

        count = 0
        while queue:
            size = len(queue)
            _, left = queue[0]
            right = -1

            for i in range(size):
                node, pos = queue.popleft()

                if i == size - 1:
                    right = pos

                if node.left:
                    queue.append((node.left, pos * 2 + 1))

                if node.right:
                    queue.append((node.right, pos * 2 + 2))

            count = max(count, right - left + 1)

        return count

if __name__ == '__main__':
    TestGen(MaximumWidthOfBinaryTree) \
        .Add(lambda tc: tc.ParamTreeNode([1,3,2,5,None,None,9,6,None,7]).Result(7)) \
        .Add(lambda tc: tc.ParamTreeNode([1,3,2,5,3,None,9]).Result(4)) \
        .Add(lambda tc: tc.ParamTreeNode([1,3,2,5]).Result(2)) \
        .Run()

# Test cases
# [1,3,2,5,3,null,9]
# [1,3,2,5,null,null,9,6,null,7]
# [1,3,2,5]
