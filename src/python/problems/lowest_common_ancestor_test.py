# https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
from models.tree_node import TreeNode


class LowestCommonAncestor:
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


LowestCommonAncestor().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(2),  TreeNode(3))
