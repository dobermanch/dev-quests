
# https://leetcode.com/problems/search-in-a-binary-search-tree

from typing import List, Optional
from core.problem_base import *
from models.tree_node import TreeNode

class SearchInABinarySearchTree(ProblemBase):
    def Solution(self, root: Optional[TreeNode], val: int) -> Optional[TreeNode]:
        def dfs(node, val):
            if not node:
                return None

            if node.val == val:
                return node

            if node.val > val:
                return dfs(node.left, val)

            return dfs(node.right, val)

        return dfs(root, val)

if __name__ == '__main__':
    TestGen(SearchInABinarySearchTree) \
        .Add(lambda tc: tc.ParamTreeNode([4,2,7,1,3]).Param(2).ResultTreeNode([2,1,3])) \
        .Add(lambda tc: tc.ParamTreeNode([4,2,7,1,3]).Param(5).ResultTreeNode([])) \
        .Run()
