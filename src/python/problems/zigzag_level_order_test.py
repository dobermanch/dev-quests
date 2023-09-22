# https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal

import collections
from typing import Optional
from models.tree_node import TreeNode

class ZigzagLevelOrder:
    def Solution(self, root: Optional[TreeNode]) -> list[list[int]]:
        if not root:
            return []

        result = []
        queue = collections.deque()
        queue.append((root, 0))

        while queue:
            node, level = queue.popleft()

            if len(result) == level:
                result.append([])
            
            if level % 2 == 0:
                result[level].append(node.val)
            else:
                result[level].insert(0, node.val)

            if node.left:
                queue.append((node.left, level + 1))
            
            if node.right:
                queue.append((node.right, level + 1))

        return result


ZigzagLevelOrder().Solution(TreeNode(1, TreeNode(2), TreeNode(3)))
