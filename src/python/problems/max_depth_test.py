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
    # TestGen(MaxDepth) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    MaxDepth().Solution(TreeNode(1, TreeNode(2), TreeNode(3)))
