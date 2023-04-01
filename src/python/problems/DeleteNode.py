# https://leetcode.com/problems/delete-node-in-a-bst

import collections

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class ZigzagLevelOrder:
    def Solution(self, root: Optional[TreeNode], key: int) -> List[List[int]]:
        def Delete(node, value):
            if not node:
                return None

            if value < node.val:
                node.left= Delete(node.left, value)
            elif value > node.val:
                node.right = Delete(node.right, value)
            else:
                if not node.right:
                    return node.left
                if not node.left:
                    return node.right
                
                newRoot = node.right
                while newRoot.left:
                    newRoot = newRoot.left

                newRoot.right = Delete(node.right, newRoot.val)
                newRoot.left = node.left
                node = newRoot

            return node

        return Delete(root, key)


ZigzagLevelOrder().Solution(TreeNode(1, TreeNode(2), TreeNode(3)))
