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
    TestGen(LowestCommonAncestorBts) \
        .Add(lambda tc: tc.ParamTreeNode([6,2,8,0,4,7,9,None,None,3,5]).ParamTreeNode([2]).ParamTreeNode([8]).ResultTreeNode([6,2,8,0,4,7,9,None,None,3,5])) \
        .Run()
