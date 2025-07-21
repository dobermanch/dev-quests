# https://leetcode.com/problems/maximum-depth-of-binary-tree/
from typing import Optional
from models.tree_node import TreeNode
from core.problem_base import *

class MaxDepth(ProblemBase):
    def Solution(self, root: Optional[TreeNode]) -> int:
        def Dfs(node, depth) -> int:
            if not node:
                return depth
            
            left = Dfs(node.left, depth)
            right = Dfs(node.right, depth)

            return 1 + max(left, right)

        return Dfs(root, 0)

if __name__ == '__main__':
    TestGen(MaxDepth) \
        .Add(lambda tc: tc.ParamTreeNode([3,9,20,None,None,15,7]).Result(3)) \
        .Add(lambda tc: tc.ParamTreeNode([1,None,2]).Result(2)) \
        .Run()
