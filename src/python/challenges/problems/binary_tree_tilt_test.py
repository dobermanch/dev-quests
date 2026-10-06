
# https://leetcode.com/problems/binary-tree-tilt

from typing import List, Optional
from core.problem_base import *
from models.tree_node import TreeNode

class BinaryTreeTilt(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        tilt = 0
        def dfs(node):
            nonlocal tilt
            if not node:
                return 0

            left = dfs(node.left)
            right = dfs(node.right)

            tilt += abs(left - right)

            return left + right + node.val

        dfs(root)
        return tilt

if __name__ == '__main__':
    TestGen(BinaryTreeTilt) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3]).Result(1)) \
        .Add(lambda tc: tc.ParamTreeNode([4,2,9,3,5,None,7]).Result(15)) \
        .Add(lambda tc: tc.ParamTreeNode([21,7,14,1,1,2,2,3,3]).Result(9)) \
        .Run()

# Test cases
# [1,2,3]
# [4,2,9,3,5,null,7]
# [21,7,14,1,1,2,2,3,3]
