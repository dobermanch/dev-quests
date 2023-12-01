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
    # TestGen(LowestCommonAncestor) \
    #     .Add(lambda tc: tc.Param([73,74,75,71,69,72,76,73]).Result([1,1,4,2,1,1,0,0])) \
    #     .Run()
    LowestCommonAncestor().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(2),  TreeNode(3))
