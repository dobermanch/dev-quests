# https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
from models.tree_node import TreeNode
from core.problem_base import *

class LowestCommonAncestor(ProblemBase):
    def Solution(self, root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
        def Dfs(node, node1, node2):
            if not node or node.val == node1.val or node.val == node2.val:
                return node

            left = Dfs(node.left, node1, node2)
            right = Dfs(node.right, node1, node2)

            if left and right:
                return node

            return left if left else right

        return Dfs(root, p, q)

if __name__ == '__main__':
    TestGen(LowestCommonAncestor) \
        .Add(lambda tc: tc.ParamTreeNode([3,5,1,6,2,0,8,None,None,7,4]).ParamTreeNode([5]).ParamTreeNode([1]).ResultTreeNode([3,5,1,6,2,0,8,None,None,7,4])) \
        .Run()
