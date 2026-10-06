
# https://leetcode.com/problems/diameter-of-binary-tree

from typing import List, Optional
from core.problem_base import *
from models.tree_node import TreeNode

class DiameterOfBinaryTree(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        depth = 0

        def dfs(node):
            nonlocal depth
            if not node:
                return 0

            left = dfs(node.left)
            right = dfs(node.right)

            depth = max(depth, left + right)

            return max(left, right) + 1

        dfs(root)
        return depth

if __name__ == '__main__':
    TestGen(DiameterOfBinaryTree) \
        .Add(lambda tc:tc.ParamTreeNode([1,2,3,4,5]).Result(3)) \
        .Add(lambda tc:tc.ParamTreeNode([1,2]).Result(1)) \
        .Run()

# Test cases
# [1,2,3,4,5]
# [1,2]
