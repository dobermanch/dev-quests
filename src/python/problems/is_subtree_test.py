# https://leetcode.com/problems/subtree-of-another-tree/

from typing import Optional
from models.tree_node import TreeNode
from core.problem_base import *

class IsSubtree(ProblemBase):
    def Solution(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        def Dfs(node1, node2, checking) -> int:
            if not node1 and not node2:
                return True
            
            if not node1 or not node2:
                return False
            
            result = node1.val == node2.val
            if result:
                result = (Dfs(node1.left, node2.left, True) and
                          Dfs(node1.right, node2.right, True))
            
            if not result and not checking:
                result = (Dfs(node1.left, node2, False) or
                          Dfs(node1.right, node2, False))

            return result

        return Dfs(root, subRoot, False)

if __name__ == '__main__':
    # TestGen(IsSubtree) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    IsSubtree().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(1, TreeNode(2), TreeNode(3)))
