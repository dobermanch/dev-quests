
# https://leetcode.com/problems/path-sum

from typing import List
from core.problem_base import *
from models.tree_node import TreeNode

class PathSum(ProblemBase):
    def Solution(self, root: TreeNode | None, targetSum: int) -> bool:
        def dfs(node, val):
            if not node:
                return False

            current = node.val + val
            if not node.left and not node.right:
                return current == targetSum

            return dfs(node.left, current) or dfs(node.right, current)

        return dfs(root, 0)

if __name__ == '__main__':
    TestGen(PathSum) \
        .Add(lambda tc: tc.ParamTreeNode([5,4,8,11,None,13,4,7,2,None,None,None,1]).Param(22).Result(True)) \
        .Add(lambda tc: tc.ParamTreeNode([1,2,3]).Param(5).Result(False)) \
        .Add(lambda tc: tc.ParamTreeNode([]).Param(0).Result(False)) \
        .Run()

# Test cases
# [5,4,8,11,null,13,4,7,2,null,null,null,1] | 22
# [1,2,3] | 5
# [] | 0
