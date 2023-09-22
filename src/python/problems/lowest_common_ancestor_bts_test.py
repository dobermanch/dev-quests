# https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

from models.tree_node import TreeNode

class LowestCommonAncestorBts:
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


LowestCommonAncestorBts().Solution(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(2),  TreeNode(3))
