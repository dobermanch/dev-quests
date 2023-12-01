# https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

from models.tree_node import TreeNode
from core.problem_base import *

class LowestCommonAncestorBts(ProblemBase):
    def Solution(self, root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
        current = root

        while current:
            if current.val > p.val and current.val > q.val:
                current = current.left
            elif current.val < p.val and current.val < q.val:
                current = current.right
            else:
                break

        return current

if __name__ == '__main__':
    # TestGen(LowestCommonAncestorBts) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    LowestCommonAncestorBts().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(2),  TreeNode(3))
