
# https://leetcode.com/problems/validate-binary-search-tree

from typing import List
from core.problem_base import *
from models.tree_node import TreeNode

class ValidateBinarySearchTree(ProblemBase):
    def Solution(self, root: TreeNode | None) -> bool:
        def dfs(node, left, right):
            if not node:
                return True

            if node.val <= left or node.val >= right:
                return False

            return (dfs(node.left, left, node.val) and
                    dfs(node.right, node.val, right))

        return dfs(root, float('-inf'), float('inf'))

if __name__ == '__main__':
    TestGen(ValidateBinarySearchTree) \
        .Add(lambda tc: tc.ParamTreeNode([2,1,3]).Result(True)) \
        .Add(lambda tc: tc.ParamTreeNode([5,1,4,None,None,3,6]).Result(False)) \
        .Run()

# Test cases
# [2,1,3]
# [5,1,4,null,null,3,6]
